FROM microsoft/aspnetcore:2.0
ARG source
WORKDIR /app
VOLUME ["/app/transmissionrss-config"]
EXPOSE 80
COPY ${source:-obj/Docker/publish} .
ENTRYPOINT ["dotnet", "TransmissionApp.Api.dll"]
