FROM microsoft/dotnet:2.2-sdk AS dotnet-builder 
ARG main
ARG eventstore

COPY ${main}*.csproj ${main}
COPY ${eventstore}*.csproj ${eventstore}

RUN dotnet restore ${main}

COPY ${main} ${main}
COPY ${eventstore} ${eventstore}

WORKDIR ${main}
RUN dotnet build
