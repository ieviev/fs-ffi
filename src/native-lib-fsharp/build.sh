#!/usr/bin/env bash

dotnet publish /p:NativeLib=Shared -c Release -r linux-x64 -o ../../lib
