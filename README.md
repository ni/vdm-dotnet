# NI Vision Development Module for .NET

#

NI Vision Development Module for .NET is a collection of .NET wrapper functions that call the core [Vision Development Module](http://www.ni.com/en-us/shop/data-acquisition-and-control/add-ons-for-data-acquisition-and-control/what-is-vision-development-module.html) (VDM) APIs.  

Vision Development Module support for 32-bit .NET was deprecated after version 2013 SP1.  New features added to Vision Development Module after that version are not available for .Net users. 

Now, NI Vision Development Module for .NET is available as an open source and intends to help users build both 32-bit and 64-bit .NET binaries: 

- NationalInstruments.Vision.dll

- NationalInstruments.Vision.Common.dll.

This project intends to provide users the ability to add new .Net APIs and build custom binaries, for all the features available in Vision Development Module (VDM). 

Note that 64-bit assemblies is minimally tested and may have issues. Some of the APIs with known issues for 64-bit.NET are as follows:

- CalibrationGetCameraParameters
- GradeDataMatrixBarcodeAim
- Sample Management
- Shape Detection
- Shape Match
- Color Segmentation
- Cooccurence Matrix
- Write and Read Classifiers

# Dependencies

#

Users need to install the following dependencies to get started: 

- Visual Studio – 2015
- .NET - 4.5
- Vision Development Module – 2018 SP1

# Getting Started

#

The following steps should be executed in order to build and use an existing .NET API:

1. Clone from the master branch.

2. Open the NIVisionDotNET.2015.sln from src\dotNet.

3. Make sure the target framework in the project-\>Properties-\>Application is set to ".NET Framework 4.5" for both projects in the NIVisionDotNET.2015.sln.
![alt text](https://github.com/ni/vdm-dotnet/blob/master/image.png)
 
4. Make sure to link "NationalInstruments.Common.dll", from \<Measurement Studio Installation directory\>\DotNET\Assemblies\Current, to NIVisionDotNetCommon.2015.csproj present in the src\dotNet folder.  

4. Build NIVisionDotNET.2015.sln. This will create NationalInstruments.Vision.dll and NationalInstruments.Vision.Common.dll in src\dotNet\bin\x86\Release or src\dotNet\bin\x64\Release based on the architecture(x86/x64).

5. Link the dlls created in step 4 to your application.

# Examples

#

Run any of the VDM examples in the Examples folder to get started. For example:

1. Open Examples\dotNET\2. Functions\Analysis\Histogram\cs\Histogram.2008 in Visual Studio 2015.
2. Navigate to Solution Explorer -\> References.
3. Modify the following references in order to pick them from the right path in your system:
    1. NationalInstruments.Vision.dll
    2. NationalInstruments.Vision.Common.dll
    3. NationalInstruments.Vision.MeasurementStudioDemo2008.dll (modify this if it is already part of References)

Pick the first two assemblies from the path where you would save your custom built NIVisionDotNET assemblies and the third from Examples/ NationalInstruments.Vision.MeasurementStudioDemo2008.dll

4. Modify the imagesPath in ExampleImagesFolder.cs to point to the example images path in your system.
5. Build the example project for x86/ x64 Release.
6. Navigate to the location where the example executable gets created (look for the path in output window while building the executable).
7. Launch the example executable from the path in step 6 and run.

# Bug Reports

#

To report a bug specific to vdm-dotnet, please use the [Github Issues page](https://github/ni/vdm-dotnet/blob/master/.github/ISSUE_TEMPLATE.md).

Fill in the issue template as completely as possible.

# Contributing

#

We welcome contributions! Please refer to [CONTRIBUTING.md](https://github/ni/vdm-dotnet/blob/master/CONTRIBUTING.md) page for information on how to contribute as well as what tests to add.

# License

#


**vdm-dotnet** is licensed under the [MIT License](https://github/ni/vdm-dotnet/blob/master/LICENSE)
