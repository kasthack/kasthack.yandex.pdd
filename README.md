# Yandex PDD API for .NET

[![Nuget](https://img.shields.io/nuget/v/kasthack.yandex.pdd.svg)](https://www.nuget.org/packages/kasthack.yandex.pdd/)
[![NuGet](https://img.shields.io/nuget/dt/kasthack.yandex.pdd.svg)](https://www.nuget.org/packages/kasthack.yandex.pdd/)
[![Build status](https://img.shields.io/appveyor/ci/kasthack/kasthack-yandex-pdd.svg)](https://ci.appveyor.com/project/kasthack/kasthack-yandex-pdd)
[![license](https://img.shields.io/github/license/kasthack/kasthack.yandex.pdd.svg)](LICENSE)
[![Join the chat at https://gitter.im/kasthack-yandex-pdd/Lobby](https://img.shields.io/gitter/room/kasthack-yandex-pdd/Lobby.svg)](https://gitter.im/kasthack-yandex-pdd/Lobby)

## Installation
```powershell
Install-Package kasthack.yandex.pdd
```
## Docs
### API Description by yandex
https://tech.yandex.ru/pdd/doc/about-docpage/
### Tokens

Admin token: https://pddimp.yandex.ru/api2/admin/get_token
Registar registration/token: https://pddimp.yandex.ru/api2/registrar/registrar

### Sample:
```c#
var unread =
    (
        await                   // we only have async methods
            new PddApi(
                "PddToken",
                /*
                    get it here: https://pddimp.yandex.ru/api2/admin/get_token
                */
                "OAuthToken"
                /*
                    Getting oauth token:
                        a)
                            build oauth uri with YaToken.GetOAuthURL
                            feed redirect uri to FromRedirectUrl
                        b)
                            implicit cast from token string like here
                */
            )
            .Domain( "who.ec" ) //get domain context
            .Mail
            .Counters( "test@who.ec" )
    )
    .Counters
    .Unread;
```
## API coverage
* Mail
    - [X] Add
    - [X] Del
    - [X] List
    - [X] Edit
    - [X] Counters
* DKIM
    - [X] Status
    - [X] Enable
    - [X] Disable
* DNS
    - [X] Add
    - [X] List
    - [X] Edit
    - [X] Delete
* Domain
    - [X] Register
    - [X] RegistrationStatus
    - [X] Details
    - [X] Delete
    - [X] SetCountry
    - [X] GetLogo
    - [X] DeleteLogo
    - [X] SetLogo
* Import
    - [X] CheckSettings
    - [X] StartOneImport
    - [X] CheckImport
    - [X] StopAllImports
* Maillist
    - [X] Add
    - [X] List
    - [X] Delete
    - [X] Subscribe
    - [X] Subscribers
    - [X] Unsubscribe
    - [X] GetCanSendOnBehalf
    - [X] SetCanSendOnBehalf
    - [X] Import file
* Domains
    - [X] List
* Deputy
    - [X] Add
    - [X] List
    - [X] Delete
