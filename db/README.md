* Database is [couchebase](https://www.couchbase.com/get-started-developing-nosql) 4.5.0-2601 Community Edition (build-2601)
* Install as a [docker image](https://hub.docker.com/r/couchbase/server/)
    - the `db` helper script will help to install / start / stop this image
* The shared data is in the ~/.couchbase/docker folder
* Admin: http://localhost:8091
    - duong / password
    - bucket: chatasp
        + port: 11211
        + value ejection, no flush
