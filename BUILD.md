# Build ~~project~~ `OpenTrader`

1. Run docker service(_linux_) or application(_windows_)
2. Execute script (wip) `project-folder/builds/[install.sh] || [install.bat]`
    * **Alternative**: Run the following commands one by one

>  Execute from context `project-folder/builds/.`

If you use old version docker, change `docker buildx` to `docker build`

```bash
#identity-db:latest
docker buildx build -t opentrader/identity-db:latest -f ./identity .
```

```bash
#web-api:latest
docker buildx build -t opentrader/web-api:latest -f .\src\applications\api\OpenTrader.WebApi\Dockerfile ..\..\
```