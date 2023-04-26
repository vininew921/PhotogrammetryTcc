# Instruções para utilizar a ESP32 com .NETnanoFramework

## 1- Instalar o .NET Desktop Development
- Abrir o Visual Studio > Get Tools and Features. (Verificar se o ".NET desktop development" já está instalado).

## 2- Instalar a Extensão .NET nanoFramework
- Visual Studio > Extensions >  Online > .NET nanoFramework Extension > install

## 3- Reinicia o Visual Studio para finalizar a instalação

## 4- Instalar a ferramenta nanoff que serve para transferir o programa para ESP32
- No terminal digite:
```
dotnet tool install -g nanoff
```

## 5- Descobrir qual é a porta serial da esp32 no seu computador
- Aperte Win+X > Device Manager > Ports (Talvez tenha que baixar o driver da placa "Silicon Labs CPxx USB" https://www.pololu.com/docs/0J7/all)

## 6- Execute o comando
``` 
nanoff --platform ESP32 --serialport com3 --update
``` 
(obs. quando executar o comando mantenha pressionado o botão boot da esp32 e de uma apertada em enable, caso de algum erro basta seguir as instruções do terminal)

## 7- Criar o projeto
Blank Application nanoFramework

# Qualquer coisa fala com o Fernandão