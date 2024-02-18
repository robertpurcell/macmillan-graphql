# macmillan-graphql
A unified GraphQL API with Hot Chocolate and Schema Stitching.

This project was used during an investigation into GraphQL with [Hot Chocolate](https://chillicream.com/docs/hotchocolate/v13). It includes three basic GraphQL servers (Account, Consent and Sitecore) and a GraphQL Gateway server which attempts to unify them.

The Account project uses authentication with Firebase and it references a [FirebaseAdminAuthentication.DependencyInjection](https://www.nuget.org/packages/FirebaseAdminAuthentication.DependencyInjection/) NuGet package for this purpose. In order to to get the authentication working then you will need to setup your own [Firebase Authentication](https://firebase.google.com/docs/auth) account and add a `firebase-config.json` configuration file to the project.

An attempt was made to containerise the project using Dockerfiles and a `docker-compose.yml` file but this work is incomplete.
