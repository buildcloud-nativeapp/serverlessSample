# Build a Full-Stack Serverless App on Azure

Supporting repository for the [A Complete Guide - Build a Full-Stack Serverless App on Azure](https://medium.com/@peiqiangw/a-complete-guide-build-a-full-stack-serverless-app-on-azure-56e75b1b533b)

## Getting Started

### Software prerequisites

Refer to **Pre-requisites**

### Architecture

Refer to **Chapter 1. Architecture Overview()**

## Quick Guide

### 1. Create a folder for your repositories 

Go to a directory to clone the repo, e.g., ```C:\Users\<username>\repos```.

### 2. Clone serverlessSample's GitHub repo 

```
git clone https://github.com/buildcloud-nativeapp/serverlessSample.git
cd serverlessSample
```

The code structure is shown below.
![code structure](/imgs/code-structure.png)

Download dependencies of the front-end project:
```
cd .\frontend\react-front-end
npm install
```

### 3. Provision Azure Resources

Refer to **Chapter 5. Provision Azure Resources**

### 4. Build and Deploy the Back-end
Refer to **Chapter 6. Integrate and Deploy the Back-end**

Include:
- 6.1 Add NuGet packages
- 6.5 Configure Cosmos DB settings
- 6.7 Test  functions locally
- 6.8 View data in Cosmos DB
- 6.9 Publish functions to Azure
- 6.10 Configure settings on Azure
- 6.11 Test the functions on Azure
- 6.12 Enable Cross-Origin Resource Sharing

### 5. Build and Deploy the Front-end
Refer to **Chapter 7. Integrate and Deploy the Front-end**
Include:
- 7.1 Add a new configuration (revisit 3.4 for local configuration)
- 7.3 Create a production build
- 7.4 Upload files to the static web site on Azure
- 7.5 Test the web app on Azure

### 6. Clean up Azure Resources
Refer to **Chapter 8. Clean up Azure Resources**
