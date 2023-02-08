az aks update -n <REPLACE_AKS> -g <REPLACE_RESOURCE_GROUP> --attach-acr <REPLACE_REGISTRY>

az acr login -n <REPLACE_REGISTRY> -u <REPLACE_USERNAME> -p <REPLACE_PASSWORD>

docker tag webapp <REPLACE_REGISTRY>/webapp
docker push  <REPLACE_REGISTRY>/webapp
