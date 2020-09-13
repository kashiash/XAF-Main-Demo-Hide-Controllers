#DropDB MainDemo
#DropDB EFCoreMainDemo
#Application MainDemoWin
#Application MainDemoWeb
#Application MainDemoBlazor
#Application EFCoreDemoBlazor

*FillForm
 User Name = Sam
*Action Log In

*Action Navigation(Roles)

*Action New

#IfDef !MainDemoBlazor, !EFCoreDemoBlazor
*Action Save and Close
#EndIf
#IfDef MainDemoBlazor, EFCoreDemoBlazor
*Action Save
#EndIf

*CheckValidationResult
 Message = Data Validation Error: Please review and correct the data validation error(s) listed below to proceed.
 Info = "Name" must not be empty.
#IfDef !MainDemoBlazor, !EFCoreDemoBlazor
*OptionalAction Close
#EndIf

*FillForm
 Name = TechWriter
#IfDef !MainDemoBlazor, !EFCoreDemoBlazor
*Action Save and Close
#EndIf
#IfDef MainDemoBlazor, EFCoreDemoBlazor
*Action Save
*Action Close
#EndIf