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
    
    
    W wersji bardziej rozwojowej chcielibyśmy mieć możliwośc właczania i wyłaczania tych kontrolerów
 
![alt text](https://content.screencast.com/users/kashiash/folders/Snagit/media/302a29be-726b-4c0a-a7dd-4ea201160e66/09.13.2020-11.40.png)

Tworzymu interfejs którym rozszerzymy model naszej aplikacji:

```csharp
 public interface IModelCustomOptions : IModelNode
    {

        [Category("Custom DetailView")]
        bool ShowDeleteActionDetailView { get; set; }


        [Category("Custom DetailView")]
        bool ShowFilterActionsDetailView { get; set; }


        [Category("Custom DetailView")]
        bool ShowNavigationActionsDetailView { get; set; }


        [Category("Custom DetailView")]
        bool ShowResetViewSettingsActionDetailView { get; set; }

        [Category("Custom DetailView")]
        bool ShowSaveActionDetailView { get; set; }


        [Category("Custom DetailView")]
        bool ShowSaveAndNewActionDetailView { get; set; }


        [Category("Custom DetailView")]
        bool ShowValidateAction { get; set; }
    }
```

rejestrujemy to rozszerzenie w podstawowym module:

```csharp
    public sealed partial class MainDemoModule : ModuleBase {
        public MainDemoModule() {
            InitializeComponent();
        }
        ...
        public override void ExtendModelInterfaces(ModelInterfaceExtenders extenders)
        {
            base.ExtendModelInterfaces(extenders);
            extenders.Add<IModelOptions, IModelCustomOptions>();
        }
        //end Hide controllers

        ...
```        

modyfikujemy kontroler aby warunkowo na podstawie ustawien z modelu właczał lub wyłaczał odpowiednie akcje:
```csharp

public   class DetailViewGlobalController : ViewController<DetailView>
    {

        protected override void OnActivated()
        {
            base.OnActivated();

            _VisibleHideAction();
        }

        protected override void OnDeactivated()
        {

            base.OnDeactivated();
        }

        private IModelCustomOptions HideActionOptions => Application.Model.Options as IModelCustomOptions;

        private void _VisibleHideAction()
        {
            _ResetViewSettingsControllerHideAction(Frame.GetController<ResetViewSettingsController>());
            _ModificationsControllerHideAction(Frame.GetController<ModificationsController>());
            _FilterControllerHideAction(Frame.GetController<FilterController>());
            _NewObjectViewController(Frame.GetController<NewObjectViewController>());
            _DeleteObjectsViewControllerHideAction(Frame.GetController<DeleteObjectsViewController>());
            _ShowAllContextsControllerHideAction(Frame.GetController<ShowAllContextsController>());
            _RecordsNavigationControllerHideAction(Frame.GetController<RecordsNavigationController>());
        }
        private void _DeleteObjectsViewControllerHideAction(DeleteObjectsViewController deleteObjectsViewController)
        {
            if (deleteObjectsViewController != null)
            {
                deleteObjectsViewController.DeleteAction.Active.SetItemValue("Visible", HideActionOptions.ShowDeleteActionDetailView);
            }
        }
        private void _FilterControllerHideAction(FilterController filterController)
        {
            if (filterController != null)
            {
                filterController.FullTextFilterAction.Active.SetItemValue("Visible", HideActionOptions.ShowFilterActionsDetailView);
            }
        }

        private void _ModificationsControllerHideAction(ModificationsController modificationsController)
        {
            if (modificationsController != null)
            {
                modificationsController.SaveAction.Active.SetItemValue("Visible", HideActionOptions.ShowSaveActionDetailView);
                modificationsController.SaveAndNewAction.Active.SetItemValue("Visible", HideActionOptions.ShowSaveAndNewActionDetailView);
            }
        }

        private void _NewObjectViewController(NewObjectViewController newObjectViewController)
        {
            if (newObjectViewController != null)
            {
                newObjectViewController.NewObjectAction.Active.SetItemValue("Visible", false);
            }
        }

        private void _RecordsNavigationControllerHideAction(RecordsNavigationController recordsNavigationController)
        {
            if (recordsNavigationController != null)
            {
                recordsNavigationController.PreviousObjectAction.Active.SetItemValue("Visible", HideActionOptions.ShowNavigationActionsDetailView);
                recordsNavigationController.NextObjectAction.Active.SetItemValue("Visible", HideActionOptions.ShowNavigationActionsDetailView);
            }
        }

        private void _ResetViewSettingsControllerHideAction(ResetViewSettingsController resetViewSettingsController)
        {
            if (resetViewSettingsController != null)
            {
                resetViewSettingsController.ResetViewSettingsAction.Active
                    .SetItemValue("Visible", HideActionOptions.ShowResetViewSettingsActionDetailView);
            }
        }

        private void _ShowAllContextsControllerHideAction(ShowAllContextsController showAllContextsController)
        {
            if (showAllContextsController != null)
            {
                showAllContextsController.ValidateAction.Active.SetItemValue("Visible", HideActionOptions.ShowValidateAction);
            }
        }
    }
```    

