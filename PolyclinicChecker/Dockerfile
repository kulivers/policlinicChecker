FROM mcr.microsoft.com/dotnet/sdk:7.0
#рабочая папка
WORKDIR /app 

#откуда куда, куда здесь = workdir
COPY . .

#Запускается когда собираем образ
RUN dotnet restore
RUN dotnet build

#порт, у меня не надо
ENV PORT 3213 
EXPOSE $PORT

# Когда запускаем образ
CMD ["dotnet", "run"]