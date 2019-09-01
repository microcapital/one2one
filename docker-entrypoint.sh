#!/bin/bash
set -e

if psql -h simpldb --username postgres -lqt | cut -d \| -f 1 | grep -qw OneTwoOne; then
    echo "OneTwoOne database existed"
else
    echo "create new database OneTwoOne"
	psql -h simpldb --username postgres -c "CREATE DATABASE OneTwoOne WITH ENCODING 'UTF8'"
	psql -h simpldb --username postgres -d OneTwoOne -a -f /app/dbscript.sql
fi

cd /app && dotnet OneTwoOne.WebHost.dll 
