# XAF-Main-Demo-Hide-Controllers

 Niekiedy jest potrzeba ukrycia standardowego kontrolera dostarczanego przez XAF. Można to zrobić za pomocą dedykowanego kontrolera, który odszuka istniejące kontrolery i akcje i je wyłączy. W przypadku chęci ukrycia kontrolera :RecordsNavigationController (strzałki przełączające pomiędzy kolejnymi rekordami) 
 
 
 ```csharp

      public class DetailViewGlobalController : ViewController<DetailView>
      {
          protected override void OnActivated()
          {
              base.OnActivated();
              var recordsNavigationController = Frame.GetController<RecordsNavigationController>();
              if (recordsNavigationController != null)
              {
                  recordsNavigationController.PreviousObjectAction.Active.SetItemValue("Visible", false);
                  recordsNavigationController.NextObjectAction.Active.SetItemValue("Visible", false);
              }
          }
          protected override void OnDeactivated()
          {
              base.OnDeactivated();
          }
      }
```
    
 
![alt text](https://content.screencast.com/users/kashiash/folders/Snagit/media/302a29be-726b-4c0a-a7dd-4ea201160e66/09.13.2020-11.40.png)



