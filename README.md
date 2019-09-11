# Azure Functions v2 MessageBird Binding Sample

This repo contains a sample project to demonstrate the architecture and plumbing needed when writing a custom binding in Azure Functions v2 for the MessageBird API. It also contains a sample implementation function written in C#. Using this as a starting point should help you understand what's going on, and help you integrate with MessageBird on Azure.

## Using the binding

To use the binding, register a new developer account with https://messagebird.com. Put the sms webhook url (`https://rest.messagebird.com/messages`) in local.settings.json with the key `MessageBirdWebHookUrl`. Put your API key in local.settings.json with the key `MessageBirdApiKey`.

> **NOTE**: The code provided here is sample code, please use as reference only and don't just copy straight into production. It has no warranty.
