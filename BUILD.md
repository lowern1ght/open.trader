# Before the build

Generate ssl certificate in directory `{project_folder}/deploy/security`

```bash

```

# Build ~~project~~ `OpenTrader`

1. Run docker service(_linux_) or application(_windows_)
2. Execute script (wip) `project-folder/builds/[install.sh] || [install.bat]`
    * **Alternative**: Run the following commands one by one

>  Execute from context `project-folder/builds/.`

If you use old version docker, change `docker buildx` to `docker build`

```bash
#identity-db:latest
docker build -t opentrader/identity-db:latest -f ./identity .
```

```bash
#s3-minio:latest
docker build -t opentrader/s3-minio:latest -f ./s3.minio .
```

```bash
#mq.pattern.rabbit:latest
docker build -t opentrader/mq-rabbit:latest -f ./mq.rabbit .
```

```bash
#web-api:latest
docker build -t opentrader/web-api:latest -f .\src\applications\api\OpenTrader.WebApi\Dockerfile ..\..\
```

### Help

```bash
#to set local images
minikube docker-env | Invoke-Expression
```