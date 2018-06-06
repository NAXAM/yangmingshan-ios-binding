﻿using System;
using Foundation;
using ObjCRuntime;
using Photos;
using UIKit;

namespace YangMingShan
{
    // @interface YMSPhotoPickerTheme : NSObject
    [BaseType(typeof(NSObject))]
    interface YMSPhotoPickerTheme
    {
        // @property (nonatomic, strong) UIColor * tintColor;
        [Export("tintColor", ArgumentSemantic.Strong)]
        UIColor TintColor { get; set; }

        // @property (nonatomic, strong) UIColor * titleLabelTextColor;
        [Export("titleLabelTextColor", ArgumentSemantic.Strong)]
        UIColor TitleLabelTextColor { get; set; }

        // @property (nonatomic, strong) UIColor * navigationBarBackgroundColor;
        [Export("navigationBarBackgroundColor", ArgumentSemantic.Strong)]
        UIColor NavigationBarBackgroundColor { get; set; }

        // @property (nonatomic, strong) UIColor * orderTintColor;
        [Export("orderTintColor", ArgumentSemantic.Strong)]
        UIColor OrderTintColor { get; set; }

        // @property (nonatomic, strong) UIColor * orderLabelTextColor;
        [Export("orderLabelTextColor", ArgumentSemantic.Strong)]
        UIColor OrderLabelTextColor { get; set; }

        // @property (nonatomic, strong) UIColor * cameraVeilColor;
        [Export("cameraVeilColor", ArgumentSemantic.Strong)]
        UIColor CameraVeilColor { get; set; }

        // @property (nonatomic, strong) UIColor * cameraIconColor;
        [Export("cameraIconColor", ArgumentSemantic.Strong)]
        UIColor CameraIconColor { get; set; }

        // @property (assign, nonatomic) UIStatusBarStyle statusBarStyle;
        [Export("statusBarStyle", ArgumentSemantic.Assign)]
        UIStatusBarStyle StatusBarStyle { get; set; }

        // @property (nonatomic, strong) UIFont * titleLabelFont;
        [Export("titleLabelFont", ArgumentSemantic.Strong)]
        UIFont TitleLabelFont { get; set; }

        // @property (nonatomic, strong) UIFont * albumNameLabelFont;
        [Export("albumNameLabelFont", ArgumentSemantic.Strong)]
        UIFont AlbumNameLabelFont { get; set; }

        // @property (nonatomic, strong) UIFont * photosCountLabelFont;
        [Export("photosCountLabelFont", ArgumentSemantic.Strong)]
        UIFont PhotosCountLabelFont { get; set; }

        // @property (nonatomic, strong) UIFont * selectionOrderLabelFont;
        [Export("selectionOrderLabelFont", ArgumentSemantic.Strong)]
        UIFont SelectionOrderLabelFont { get; set; }

        // +(instancetype)sharedInstance;
        [Static]
        [Export("sharedInstance")]
        YMSPhotoPickerTheme SharedInstance();

        // -(void)reset;
        [Export("reset")]
        void Reset();
    }

    // @interface YMSPhotoPickerViewController : UIViewController
    [BaseType(typeof(UIViewController))]
    interface YMSPhotoPickerViewController
    {
        [Wrap("WeakDelegate")]
        YMSPhotoPickerViewControllerDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<YMSPhotoPickerViewControllerDelegate> delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // @property (assign, nonatomic) NSUInteger numberOfPhotoToSelect;
        [Export("numberOfPhotoToSelect")]
        nuint NumberOfPhotoToSelect { get; set; }

        // @property (readonly, nonatomic) YMSPhotoPickerTheme * theme;
        [Export("theme")]
        YMSPhotoPickerTheme Theme { get; }

        // @property (assign, nonatomic) BOOL shouldReturnImageForSingleSelection;
        [Export("shouldReturnImageForSingleSelection")]
        bool ShouldReturnImageForSingleSelection { get; set; }
    }

    partial interface IYMSPhotoPickerViewControllerDelegate { }

    // @protocol YMSPhotoPickerViewControllerDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface YMSPhotoPickerViewControllerDelegate
    {
        // @required -(void)photoPickerViewControllerDidReceivePhotoAlbumAccessDenied:(YMSPhotoPickerViewController *)picker;
        [Abstract]
        [Export("photoPickerViewControllerDidReceivePhotoAlbumAccessDenied:")]
        void PhotoPickerViewControllerDidReceivePhotoAlbumAccessDenied(YMSPhotoPickerViewController picker);

        // @required -(void)photoPickerViewControllerDidReceiveCameraAccessDenied:(YMSPhotoPickerViewController *)picker;
        [Abstract]
        [Export("photoPickerViewControllerDidReceiveCameraAccessDenied:")]
        void PhotoPickerViewControllerDidReceiveCameraAccessDenied(YMSPhotoPickerViewController picker);

        // @optional -(void)photoPickerViewController:(YMSPhotoPickerViewController *)picker didFinishPickingImage:(UIImage *)image;
        [Export("photoPickerViewController:didFinishPickingImage:")]
        void PhotoPickerViewController(YMSPhotoPickerViewController picker, UIImage image);

        // @optional -(void)photoPickerViewController:(YMSPhotoPickerViewController *)picker didFinishPickingImages:(NSArray<PHAsset *> *)photoAssets;
        [Export("photoPickerViewController:didFinishPickingImages:")]
        void PhotoPickerViewController(YMSPhotoPickerViewController picker, PHAsset[] photoAssets);

        // @optional -(void)photoPickerViewControllerDidCancel:(YMSPhotoPickerViewController *)picker;
        [Export("photoPickerViewControllerDidCancel:")]
        void PhotoPickerViewControllerDidCancel(YMSPhotoPickerViewController picker);
    }

    // @interface YMSPhotoHelper (UIViewController)
    [Category]
    [BaseType(typeof(UIViewController))]
    interface UIViewController_YMSPhotoHelper
    {
        // -(void)yms_presentCameraCaptureViewWithDelegate:(id<UIImagePickerControllerDelegate,UINavigationControllerDelegate>)delegate;
        [Export("yms_presentCameraCaptureViewWithDelegate:")]
        void Yms_presentCameraCaptureViewWithDelegate(IUIImagePickerControllerDelegate @delegate);

        // -(void)yms_presentAlbumPhotoViewWithDelegate:(id<YMSPhotoPickerViewControllerDelegate>)delegate;
        [Export("yms_presentAlbumPhotoViewWithDelegate:")]
        void Yms_presentAlbumPhotoViewWithDelegate(IYMSPhotoPickerViewControllerDelegate @delegate);

        // -(void)yms_presentCustomAlbumPhotoView:(YMSPhotoPickerViewController *)pickerViewController delegate:(id<YMSPhotoPickerViewControllerDelegate>)delegate;
        [Export("yms_presentCustomAlbumPhotoView:delegate:")]
        void Yms_presentCustomAlbumPhotoView(YMSPhotoPickerViewController pickerViewController, IYMSPhotoPickerViewControllerDelegate @delegate);
    }
}
