Imports System
Imports Microsoft.Win32

''' <summary>
''' Class to get the NI Vision example images folder
''' </summary>
Public NotInheritable Class ExampleImagesFolder
	Private Sub New()
	End Sub
	Public Shared Function GetExampleImagesFolder() As String
	    Dim key As RegistryKey = Registry.LocalMachine
	    key = key.OpenSubKey("SOFTWARE\National Instruments\IMAQ Vision\CurrentVersion")
	    Dim imagesPath As String = DirectCast(key.GetValue("ExampleImagePath"), String)
	    key.Close()
	    Return imagesPath
	End Function
End Class
