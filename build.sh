#!/usr/bin/env bash
repoFolder="$( cd "$( dirname "${BASH_SOURCE[0]}" )" && pwd )"
cd $repoFolder

tataBuildZip="https://github.com/E-Playboys/TaTa/archive/1.0.zip"
if [ ! -z $tataBUILD_ZIP ]; then
    tataBuildZip=$tataBUILD_ZIP
fi

buildFolder="./"
buildFile="$buildFolder/build.sh"

if test ! -d $buildFolder; then
    echo "Downloading tataBuild from $tataBuildZip"

    tempFolder="/tmp/tataBuild-$(uuidgen)"
    mkdir $tempFolder

    localZipFile="$tempFolder/tatabuild.zip"

    retries=6
    until (wget -O $localZipFile $tataBuildZip 2>/dev/null || curl -o $localZipFile --location $tataBuildZip 2>/dev/null)
    do
        echo "Failed to download '$tataBuildZip'"
        if [ "$retries" -le 0 ]; then
            exit 1
        fi
        retries=$((retries - 1))
        echo "Waiting 10 seconds before retrying. Retries left: $retries"
        sleep 10s
    done

    unzip -q -d $tempFolder $localZipFile

    mkdir $buildFolder
    cp -r $tempFolder/**/build/** $buildFolder

    chmod +x $buildFile

    # Cleanup
    if test -d $tempFolder; then
        rm -rf $tempFolder
    fi
fi

$buildFile -r $repoFolder "$@"
