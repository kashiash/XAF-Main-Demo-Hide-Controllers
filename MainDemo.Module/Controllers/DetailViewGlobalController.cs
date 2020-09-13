using DevExpress.ExpressApp;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Validation.AllContextsView;
using MainDemo.Module.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Hide controllers

namespace MainDemo.Module.Controllers
{
    public class ViewGlobalController : ViewController
    {
        private IModelCustomOptions HideActionOptions => Application.Model.Options as IModelCustomOptions;

        protected override void OnActivated()
        {
            base.OnActivated();

          //  VisibleHideAction();
        }

        //private void OpenObjectControllerHideAction(OpenObjectController openObjectController)
        //{
        //    if (openObjectController != null)
        //    {
        //        openObjectController.OpenObjectAction.Active.SetItemValue("Visible", HideActionOptions.ShowOpenObjectAction);
        //    }
        //}

        //private void SvgSkinControllerHideAction(SvgSkinController controller)
        //{
        //    if (controller != null && !((IModelGabosOptions)Application.Model.Options).ShowSvgSkinAction)
        //    {
        //        foreach (ActionBase action in controller.Actions)
        //        {
        //            action.Active.SetItemValue("Visible", false);
        //        }
        //    }
        //}

        //private void VisibleHideAction()
        //{
        //    SvgSkinControllerHideAction(Frame.GetController<SvgSkinController>());
        //    OpenObjectControllerHideAction(Frame.GetController<OpenObjectController>());
        //}
    }
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
}
