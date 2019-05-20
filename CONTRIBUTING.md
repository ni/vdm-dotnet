#
# Contributing to vdm-dotnet

Contributions to vdm-dotnet are welcome from all!

vdm-dotnet is managed via [git](https://git-scm.com/), with the canonical upstream repository hosted on [GitHub](https://github.com/ni/vdm-dotnet/).

vdm-dotnet follows a pull-request model for development. If you wish to contribute, you will need to create a GitHub account, fork this project, push a branch with your changes to your project, and then submit a pull request.

See [GitHub&#39;s official documentation](https://help.github.com/articles/using-pull-requests/) for more details.

# Getting Started

The following steps describe the process of adding new APIs:

1. Let us first start with an already existing function which is ConcentricRake2. Get the corresponding function prototype from nivision.h header file where the unmanaged entrypoints are declared. You can find nivision.h at \<National Instruments Installation Directory\>\Vision\Include.

imaqConcentricRake is declared as follows in nivision.h file.

IMAQ_FUNCConcentricRakeReport2*      IMAQ_STDCALLimaqConcentricRake2(Image* image, ROI* roi, ConcentricRakeDirection direction, EdgeProcess process, int stepSize, EdgeOptions2* edgeOptions);

Import the C entrypoint in **Internal/DLLImports.cs** as follows:

**DLLImports.cs**

[DllImport("nivision.dll")]

internalstaticexternIntPtr imaqConcentricRake2(IntPtr _image, IntPtr _roi, ConcentricRakeDirection _direction, EdgeProcess _process, Int32 _stepSize, refCVI_EdgeOptions2 _edgeOptions);

Note that all the pointers are substituted with IntPtr. Or you can pass the actual structure as a ref (for a pointer) like what has been done in case of CVI_EdgeOptions2. ConcentricRakeDirection and EdgeProcess are enums.

2. Declare the enums similar to what is found in nivision.h in **Structures.cs**. In the above example, ConcentricRakeDirection and EdgeProcess are enums (refer to those declarations in **Structures.cs** ).

3. Now declare a dotNet wrapper method ConcentricRake in **Algorithms.cs,** which calls the unmanaged method imaqConcentricRake2. The wrapper method will be a public static method. The wrapper method generally has similar inputs and return type as the unmanaged function.  The wrapper method should also do data checks so that valid data is passed into the unmanaged method:

 **Algorithms.cs**

 public static ConcentricRakeReport ConcentricRake(VisionImage image, Roi annulus, ConcentricRakeDirection direction, EdgeProcess process, Int32 stepSize, EdgeOptions edgeOptions)

         {

             if (image == null) { throw new ArgumentNullException("image"); }

             image.ThrowIfDisposed();

             if (annulus == null) {throw new ArgumentNullException("annulus");}

             annulus.ThrowIfDisposed();

             if (edgeOptions == null) { throw new ArgumentNullException("edgeOptions"); }

             CVI_EdgeOptions2 cviEdgeOptions = newCVI_EdgeOptions2();

             cviEdgeOptions.ConvertFromExternal(edgeOptions);

             IntPtr report = VisionDll.imaqConcentricRake2(image._image, annulus._roi, direction, process, stepSize, ref cviEdgeOptions);

             Utilities.ThrowError(report);

             return Utilities.ConvertIntPtrToStructure<ConcentricRakeReport, CVI_ConcentricRakeReport2>(report, true);

         }

4. The above step imaqConcentricRake2 returns an IntPtr which is stored as part of "report" variable.  Now we need a method to convert the data structure returned by imaqConcentricRake2 to a dotNet structure. The utility method which does this conversion is Utilities.ConvertIntPtrToStructure which is defined as:

 **Internal/Utilties.cs**

         public static E ConvertIntPtrToStructure<E, I>(IntPtr ptr, bool dispose) where I: IHasExternalVersionOut<E>

         {

             E toReturn = ((I)Marshal.PtrToStructure(ptr, typeof(I))).ConvertToExternal();

             if (dispose)

             {

                 VisionDllCommon.imaqDispose(ptr);

             }

             return toReturn;

         }

 In the case of concentric rake, we want to convert from CVI_ConcentricRakeReport2 to ConcentricRakeReport. Here CVI_ConcentricRakeReport2 structure should match exactly to the corresponding CVI structure defined innivision.h ( ConcentricRakeReport2).

 **nivision.h**

 typedefstructConcentricRakeReport2_struct {

     EdgeInfo*      firstEdges;

     unsignedint   numFirstEdges;

     EdgeInfo*      lastEdges;

     unsignedint   numLastEdges;

     SearchArcInfo* searchArcs;

     unsignedint   numSearchArcs;

 } ConcentricRakeReport2;

  **DLLImports.cs**

 #if (Bit32)

         [StructLayout(LayoutKind.Sequential, Pack = 1)]

 #else 

         [StructLayout(LayoutKind.Sequential)]

 #endif 

 internalstructCVI_ConcentricRakeReport2 : IHasExternalVersionOut<ConcentricRakeReport>

 {

        privateIntPtr _firstEdges;

        privateUInt32 _numFirstEdges;

        privateIntPtr _lastEdges;

        privateUInt32 _numLastEdges;

        privateIntPtr _searchArcs;

        privateUInt32 _numSearchArcs;

        publicConcentricRakeReport ConvertToExternal ()

        {

        ConcentricRakeReport report = newConcentricRakeReport();

        report.FirstEdges = Utilities.ConvertIntPtrToCollection<EdgeInfo,   CVI_EdgeInfo>(_firstEdges, _numFirstEdges, false);

        report.LastEdges = Utilities.ConvertIntPtrToCollection<EdgeInfo,  CVI_EdgeInfo>(_lastEdges, _numLastEdges, false);

        report.SearchArcs = Utilities.ConvertIntPtrToCollection<SearchArcInfo,  CVI_SearchArcInfo>(_searchArcs, _numSearchArcs, false);

        return report;

        }

 }



 The structure implements IHasExternalVersionOut which helps in converting to the final state ConcentricRakeReport. InConvertToExternal() function, we convert all individual structure members to their corresponding dotNetTypes. This applies to nested structures as well.

 [StructLayout(LayoutKind.Sequential)] specifies that the fields of the type should be laid out in memory in the same order they are declared in your source code. That's often important when interoperating with native code. Without the attribute the Common Language Runtime (CLR) is free to optimize memory use by rearranging the fields. For 32-bit, packing is 1 byte whereas for 64-bit, it's default 4 byte.

5. Define ConcentricRakeReport in Structure.cs which will be filled up byConvertToExternal in step4. (Refer to public sealed class ConcentricRakeReport in Structure.cs for details).

# Testing

Add an xunit test in the test solution &quot;VisionTestLibrary&quot; present in tests/VisionTestLibrary folder. Refer to the already existing test template in VisionTests.cs to add new tests. For more information on getting started with xunit, please refer:

 [https://xunit.net/](https://xunit.net/)

 [https://xunit.net/docs/getting-started/netfx/visual-studio](https://xunit.net/docs/getting-started/netfx/visual-studio)

# Developer Certificate of Origin (DCO)

Developer&#39;s Certificate of Origin 1.1

By making a contribution to this project, I certify that:

(a) The contribution was created in whole or in part by me and I have the right to submit it under the open source license indicated in the file; or

(b) The contribution is based upon previous work that, to the best of my knowledge, is covered under an appropriate open source license and I have the right under that license to submit that work with modifications, whether created in whole or in part by me, under the same open source license (unless I am permitted to submit under a different license), as indicated in the file; or

(c) The contribution was provided directly to me by some other person who certified (a), (b) or (c) and I have not modified it.

(d) I understand and agree that this project and the contribution are public and that a record of the contribution (including all personal information I submit with it, including my sign-off) is maintained indefinitely and may be redistributed consistent with this project or the open source license(s) involved.

(From [developercertificate.org](https://developercertificate.org/))

See [LICENSE](https://github.com/ni/vdm-dotnet/blob/master/LICENSE) for details about how vdm-dotnet is licensed.
