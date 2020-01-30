using System;
using Com.Visioglobe.Visiomoveessential.Model;
using CoreGraphics;
using CoreLocation;
using Foundation;
using ObjCRuntime;
using UIKit;

// @interface VMEPosition : NSObject <NSCopying>
[BaseType(typeof(NSObject))]
interface VMEPosition : INSCopying
{
	// -(instancetype)initWithLatitude:(double)latitude longitude:(double)longitude altitude:(double)altitude buildingID:(NSString *)buildingID floorID:(NSString *)floorID;
	[Export("initWithLatitude:longitude:altitude:buildingID:floorID:")]
	IntPtr Constructor(double latitude, double longitude, double altitude, string buildingID, string floorID);

	// -(instancetype)initWithLatitude:(double)latitude longitude:(double)longitude altitude:(double)altitude;
	[Export("initWithLatitude:longitude:altitude:")]
	IntPtr Constructor(double latitude, double longitude, double altitude);

	// -(BOOL)isEqualToPosition:(VMEPosition *)position;
	[Export("isEqualToPosition:")]
	bool IsEqualToPosition(VMEPosition position);

	// @property (nonatomic) double latitude;
	[Export("latitude")]
	double Latitude { get; set; }

	// @property (nonatomic) double longitude;
	[Export("longitude")]
	double Longitude { get; set; }

	// @property (nonatomic) double altitude;
	[Export("altitude")]
	double Altitude { get; set; }

	// @property (nonatomic, strong) NSString * buildingID;
	[Export("buildingID", ArgumentSemantic.Strong)]
	string BuildingID { get; set; }

	// @property (nonatomic, strong) NSString * floorID;
	[Export("floorID", ArgumentSemantic.Strong)]
	string FloorID { get; set; }
}

// @interface VMERouteRequest : NSObject <NSCopying>
[BaseType(typeof(NSObject))]
interface VMERouteRequest : INSCopying
{
	// -(instancetype)initWithAccessible:(BOOL)isAccessible optimize:(BOOL)isOptimized __attribute__((deprecated("Please use initWithRequestType:destinationsOrder:accessible:")));
	[Export("initWithAccessible:optimize:")]
	IntPtr Constructor(bool isAccessible, bool isOptimized);

	// -(instancetype)initWithRequestType:(VMERouteRequestType)requestType destinationsOrder:(VMERouteDestinationsOrder)destinationsOrder;
	[Export("initWithRequestType:destinationsOrder:")]
	IntPtr Constructor(VMERouteRequestType requestType, VMERouteDestinationsOrder destinationsOrder);

	// -(instancetype)initWithRequestType:(VMERouteRequestType)requestType destinationsOrder:(VMERouteDestinationsOrder)destinationsOrder accessible:(BOOL)isAccessible;
	[Export("initWithRequestType:destinationsOrder:accessible:")]
	IntPtr Constructor(VMERouteRequestType requestType, VMERouteDestinationsOrder destinationsOrder, bool isAccessible);

	// -(id)getOrigin;
	[Export("getOrigin")]
	[Verify(MethodToProperty)]
	NSObject Origin { get; }

	// -(void)setOriginWithPlaceID:(NSString *)placeID __attribute__((deprecated("Please use setOrigin:")));
	[Export("setOriginWithPlaceID:")]
	void SetOriginWithPlaceID(string placeID);

	// -(void)setOriginWithLocation:(CLLocation *)location __attribute__((deprecated("Please use setOrigin:")));
	[Export("setOriginWithLocation:")]
	void SetOriginWithLocation(CLLocation location);

	// -(void)setOrigin:(id)origin;
	[Export("setOrigin:")]
	void SetOrigin(NSObject origin);

	// -(NSArray *)getDestinations;
	[Export("getDestinations")]
	[Verify(MethodToProperty), Verify(StronglyTypedNSArray)]
	NSObject[] Destinations { get; }

	// -(BOOL)addDestination:(id)destination;
	[Export("addDestination:")]
	bool AddDestination(NSObject destination);

	// -(BOOL)addDestinations:(NSArray *)destinations;
	[Export("addDestinations:")]
	[Verify(StronglyTypedNSArray)]
	bool AddDestinations(NSObject[] destinations);

	// -(void)removeAllDestinations;
	[Export("removeAllDestinations")]
	void RemoveAllDestinations();

	// -(void)removeDestinationAtIndex:(NSUInteger)index;
	[Export("removeDestinationAtIndex:")]
	void RemoveDestinationAtIndex(nuint index);

	// -(BOOL)replaceDestinationAtIndex:(NSUInteger)index withDestination:(id)destination;
	[Export("replaceDestinationAtIndex:withDestination:")]
	bool ReplaceDestinationAtIndex(nuint index, NSObject destination);

	// -(BOOL)isEqualToRouteRequest:(VMERouteRequest *)routeRequest;
	[Export("isEqualToRouteRequest:")]
	bool IsEqualToRouteRequest(VMERouteRequest routeRequest);

	// @property (nonatomic) BOOL isAccessible;
	[Export("isAccessible")]
	bool IsAccessible { get; set; }

	// @property (readonly) BOOL isOptimal __attribute__((deprecated("Please use destinationsOrder")));
	[Export("isOptimal")]
	bool IsOptimal { get; }

	// @property (nonatomic) VMERouteDestinationsOrder destinationsOrder;
	[Export("destinationsOrder", ArgumentSemantic.Assign)]
	VMERouteDestinationsOrder DestinationsOrder { get; set; }

	// @property (nonatomic) VMERouteRequestType requestType;
	[Export("requestType", ArgumentSemantic.Assign)]
	VMERouteRequestType RequestType { get; set; }
}

// @interface VMERouteResult : NSObject <NSCopying>
[BaseType(typeof(NSObject))]
interface VMERouteResult : INSCopying
{
	// -(instancetype)initWithDestinations:(NSArray *)destinations duration:(double)duration length:(double)length;
	[Export("initWithDestinations:duration:length:")]
	[Verify(StronglyTypedNSArray)]
	IntPtr Constructor(NSObject[] destinations, double duration, double length);

	// -(BOOL)isEqualToRouteResult:(VMERouteRequest *)routeRequest;
	[Export("isEqualToRouteResult:")]
	bool IsEqualToRouteResult(VMERouteRequest routeRequest);

	// @property (readonly) double duration;
	[Export("duration")]
	double Duration { get; }

	// @property (readonly) double length;
	[Export("length")]
	double Length { get; }

	// @property (readonly) NSArray * destinations;
	[Export("destinations")]
	[Verify(StronglyTypedNSArray)]
	NSObject[] Destinations { get; }
}

// @protocol VMEComputeRouteCallback <NSObject>
/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
[Protocol]
[BaseType(typeof(NSObject))]
interface VMEComputeRouteCallback
{
	// @optional -(void)computeRouteDidFinish:(VMEMapView *)mapView parameters:(VMERouteRequest *)routeRequest __attribute__((deprecated("Please use computeRouteDidFinish:parameters:result:")));
	[Export("computeRouteDidFinish:parameters:")]
	void ComputeRouteDidFinish(VMEMapView mapView, VMERouteRequest routeRequest);

	// @required -(BOOL)computeRouteDidFinish:(VMEMapView *)mapView parameters:(VMERouteRequest *)routeRequest result:(VMERouteResult *)routeResult;
	[Abstract]
	[Export("computeRouteDidFinish:parameters:result:")]
	bool ComputeRouteDidFinish(VMEMapView mapView, VMERouteRequest routeRequest, VMERouteResult routeResult);

	// @required -(void)computeRouteDidFail:(VMEMapView *)mapView parameters:(VMERouteRequest *)routeRequest error:(NSString *)error;
	[Abstract]
	[Export("computeRouteDidFail:parameters:error:")]
	void ComputeRouteDidFail(VMEMapView mapView, VMERouteRequest routeRequest, string error);
}

// @protocol VMEComputeRouteInterface <NSObject>
/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
[Protocol]
[BaseType(typeof(NSObject))]
interface VMEComputeRouteInterface
{
	// @required -(void)computeRoute:(VMERouteRequest *)routeRequest callback:(id<VMEComputeRouteCallback>)callback;
	[Abstract]
	[Export("computeRoute:callback:")]
	void Callback(VMERouteRequest routeRequest, VMEComputeRouteCallback callback);
}

// @interface VMELocation : NSObject <NSCopying>
[BaseType(typeof(NSObject))]
interface VMELocation : INSCopying
{
	// -(instancetype)initWithPosition:(VMEPosition *)position bearing:(double)bearing accuracy:(double)accuracy;
	[Export("initWithPosition:bearing:accuracy:")]
	IntPtr Constructor(VMEPosition position, double bearing, double accuracy);

	// @property (nonatomic) VMEPosition * position;
	[Export("position", ArgumentSemantic.Assign)]
	VMEPosition Position { get; set; }

	// @property (nonatomic) double accuracy;
	[Export("accuracy")]
	double Accuracy { get; set; }

	// @property (nonatomic) double bearing;
	[Export("bearing")]
	double Bearing { get; set; }
}

// @protocol VMELocationInterface <NSObject>
/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
[Protocol]
[BaseType(typeof(NSObject))]
interface VMELocationInterface
{
	// @required -(void)updateLocation:(VMELocation *)update;
	[Abstract]
	[Export("updateLocation:")]
	void UpdateLocation(VMELocation update);

	// @required -(VMELocation *)createLocationFromLocation:(CLLocation *)location;
	[Abstract]
	[Export("createLocationFromLocation:")]
	VMELocation CreateLocationFromLocation(CLLocation location);

	// @required -(VMEPosition *)createPositionFromLocation:(CLLocation *)location;
	[Abstract]
	[Export("createPositionFromLocation:")]
	VMEPosition CreatePositionFromLocation(CLLocation location);
}

// @interface VMECameraHeading : NSObject
[BaseType(typeof(NSObject))]
interface VMECameraHeading
{
	// +(instancetype)cameraHeadingCurrent;
	[Static]
	[Export("cameraHeadingCurrent")]
	VMECameraHeading CameraHeadingCurrent();

	// +(instancetype)cameraHeadingForPlaceID:(NSString *)placeID;
	[Static]
	[Export("cameraHeadingForPlaceID:")]
	VMECameraHeading CameraHeadingForPlaceID(string placeID);

	// +(instancetype)cameraHeadingWithHeading:(float)heading;
	[Static]
	[Export("cameraHeadingWithHeading:")]
	VMECameraHeading CameraHeadingWithHeading(float heading);
}

// @interface VMECameraUpdate : NSObject
[BaseType(typeof(NSObject))]
interface VMECameraUpdate
{
	// -(instancetype)initWithViewMode:(VMEViewMode)viewMode buildingID:(NSString *)buildingID floorID:(NSString *)floorID __attribute__((deprecated("Please use either: cameraUpdateForViewMode:heading:, cameraUpdateForViewMode:heading:buildingID: or cameraUpdateForViewMode:heading:floorID:")));
	[Export("initWithViewMode:buildingID:floorID:")]
	IntPtr Constructor(VMEViewMode viewMode, string buildingID, string floorID);

	// -(instancetype)initWithPlaceID:(NSString *)placeID __attribute__((deprecated("Please use cameraUpdateForPlaceID:")));
	[Export("initWithPlaceID:")]
	IntPtr Constructor(string placeID);

	// -(instancetype)initWithPositions:(NSArray *)positions marginTop:(NSUInteger)marginTop marginBottom:(NSUInteger)marginBottom marginLeft:(NSUInteger)marginLeft marginRight:(NSUInteger)marginRight heading:(NSNumber *)heading __attribute__((deprecated("Please use cameraUpdateForPositions:heading:paddingTop:paddingBottom:paddingLeft:paddingRight")));
	[Export("initWithPositions:marginTop:marginBottom:marginLeft:marginRight:heading:")]
	[Verify(StronglyTypedNSArray)]
	IntPtr Constructor(NSObject[] positions, nuint marginTop, nuint marginBottom, nuint marginLeft, nuint marginRight, NSNumber heading);

	// +(instancetype)cameraUpdateReset;
	[Static]
	[Export("cameraUpdateReset")]
	VMECameraUpdate CameraUpdateReset();

	// +(instancetype)cameraUpdateResetWithHeading:(VMECameraHeading *)heading;
	[Static]
	[Export("cameraUpdateResetWithHeading:")]
	VMECameraUpdate CameraUpdateResetWithHeading(VMECameraHeading heading);

	// +(instancetype)cameraUpdateForViewMode:(VMEViewMode)viewMode heading:(VMECameraHeading *)heading;
	[Static]
	[Export("cameraUpdateForViewMode:heading:")]
	VMECameraUpdate CameraUpdateForViewMode(VMEViewMode viewMode, VMECameraHeading heading);

	// +(instancetype)cameraUpdateForViewMode:(VMEViewMode)viewMode heading:(VMECameraHeading *)heading buildingID:(NSString *)buildingID;
	[Static]
	[Export("cameraUpdateForViewMode:heading:buildingID:")]
	VMECameraUpdate CameraUpdateForViewMode(VMEViewMode viewMode, VMECameraHeading heading, string buildingID);

	// +(instancetype)cameraUpdateForViewMode:(VMEViewMode)viewMode heading:(VMECameraHeading *)heading floorID:(NSString *)floorID;
	[Static]
	[Export("cameraUpdateForViewMode:heading:floorID:")]
	VMECameraUpdate CameraUpdateForViewMode(VMEViewMode viewMode, VMECameraHeading heading, string floorID);

	// +(instancetype)cameraUpdateForPlaceID:(NSString *)placeID;
	[Static]
	[Export("cameraUpdateForPlaceID:")]
	VMECameraUpdate CameraUpdateForPlaceID(string placeID);

	// +(instancetype)cameraUpdateForPlaceID:(NSString *)placeID heading:(VMECameraHeading *)heading paddingTop:(CGFloat)top paddingBottom:(CGFloat)bottom paddingLeft:(CGFloat)left paddingRight:(CGFloat)right;
	[Static]
	[Export("cameraUpdateForPlaceID:heading:paddingTop:paddingBottom:paddingLeft:paddingRight:")]
	VMECameraUpdate CameraUpdateForPlaceID(string placeID, VMECameraHeading heading, nfloat top, nfloat bottom, nfloat left, nfloat right);

	// +(instancetype)cameraUpdateForPositions:(NSArray *)positions heading:(VMECameraHeading *)heading paddingTop:(CGFloat)top paddingBottom:(CGFloat)bottom paddingLeft:(CGFloat)left paddingRight:(CGFloat)right;
	[Static]
	[Export("cameraUpdateForPositions:heading:paddingTop:paddingBottom:paddingLeft:paddingRight:")]
	[Verify(StronglyTypedNSArray)]
	VMECameraUpdate CameraUpdateForPositions(NSObject[] positions, VMECameraHeading heading, nfloat top, nfloat bottom, nfloat left, nfloat right);

	// +(instancetype)cameraUpdateForPosition:(VMEPosition *)position heading:(VMECameraHeading *)heading minAltitude:(double)minAltitude maxAltitude:(double)maxAltitude;
	[Static]
	[Export("cameraUpdateForPosition:heading:minAltitude:maxAltitude:")]
	VMECameraUpdate CameraUpdateForPosition(VMEPosition position, VMECameraHeading heading, double minAltitude, double maxAltitude);
}

// @interface VMESceneUpdate : NSObject
[BaseType(typeof(NSObject))]
interface VMESceneUpdate
{
	// +(instancetype)sceneUpdateForViewMode:(VMEViewMode)viewMode;
	[Static]
	[Export("sceneUpdateForViewMode:")]
	VMESceneUpdate SceneUpdateForViewMode(VMEViewMode viewMode);

	// +(instancetype)sceneUpdateForViewMode:(VMEViewMode)viewMode buildingID:(NSString *)buildingID;
	[Static]
	[Export("sceneUpdateForViewMode:buildingID:")]
	VMESceneUpdate SceneUpdateForViewMode(VMEViewMode viewMode, string buildingID);

	// +(instancetype)sceneUpdateForViewMode:(VMEViewMode)viewMode floorID:(NSString *)floorID;
	[Static]
	[Export("sceneUpdateForViewMode:floorID:")]
	VMESceneUpdate SceneUpdateForViewMode(VMEViewMode viewMode, string floorID);
}

// @protocol VMEMapInterface <NSObject>
/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
[Protocol]
[BaseType(typeof(NSObject))]
interface VMEMapInterface
{
	// @required -(void)moveCamera:(VMECameraUpdate *)update animated:(BOOL)animated __attribute__((deprecated("Please use either animateCamera: or updateCamera:")));
	[Abstract]
	[Export("moveCamera:animated:")]
	void MoveCamera(VMECameraUpdate update, bool animated);

	// @required -(void)updateCamera:(VMECameraUpdate *)update;
	[Abstract]
	[Export("updateCamera:")]
	void UpdateCamera(VMECameraUpdate update);

	// @required -(void)animateCamera:(VMECameraUpdate *)update;
	[Abstract]
	[Export("animateCamera:")]
	void AnimateCamera(VMECameraUpdate update);

	// @required -(void)updateScene:(VMESceneUpdate *)update;
	[Abstract]
	[Export("updateScene:")]
	void UpdateScene(VMESceneUpdate update);

	// @required -(void)animateScene:(VMESceneUpdate *)update;
	[Abstract]
	[Export("animateScene:")]
	void AnimateScene(VMESceneUpdate update);
}

// @protocol VMEMapListener <NSObject>
/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
[Protocol]
[BaseType(typeof(NSObject))]
interface VMEMapListener
{
	// @optional -(void)mapReadyForPlaceUpdate:(VMEMapView *)mapView;
	[Export("mapReadyForPlaceUpdate:")]
	void MapReadyForPlaceUpdate(VMEMapView mapView);

	// @optional -(void)mapDidLoad:(VMEMapView *)mapView;
	[Export("mapDidLoad:")]
	void MapDidLoad(VMEMapView mapView);

	// @optional -(BOOL)map:(VMEMapView *)mapView didSelectPlace:(NSString *)placeID withPosition:(VMEPosition *)position;
	[Export("map:didSelectPlace:withPosition:")]
	bool Map(VMEMapView mapView, string placeID, VMEPosition position);
}

// @protocol VMEOverlayViewInterface <NSObject>
/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
[Protocol]
[BaseType(typeof(NSObject))]
interface VMEOverlayViewInterface
{
	// @required -(BOOL)addOverlayViewID:(NSString *)overlayViewID view:(UIView *)view position:(VMEPosition *)position;
	[Abstract]
	[Export("addOverlayViewID:view:position:")]
	bool AddOverlayViewID(string overlayViewID, UIView view, VMEPosition position);

	// @required -(BOOL)addOverlayViewID:(NSString *)overlayViewID view:(UIView *)view placeID:(NSString *)placeID;
	[Abstract]
	[Export("addOverlayViewID:view:placeID:")]
	bool AddOverlayViewID(string overlayViewID, UIView view, string placeID);

	// @required -(BOOL)setOverlayViewID:(NSString *)overlayViewID position:(VMEPosition *)position;
	[Abstract]
	[Export("setOverlayViewID:position:")]
	bool SetOverlayViewID(string overlayViewID, VMEPosition position);

	// @required -(BOOL)setOverlayViewID:(NSString *)overlayViewID placeID:(NSString *)placeID;
	[Abstract]
	[Export("setOverlayViewID:placeID:")]
	bool SetOverlayViewID(string overlayViewID, string placeID);

	// @required -(BOOL)removeOverlayViewID:(NSString *)overlayViewID;
	[Abstract]
	[Export("removeOverlayViewID:")]
	bool RemoveOverlayViewID(string overlayViewID);
}

// @interface VMEPlaceOrientation : NSObject
[BaseType(typeof(NSObject))]
interface VMEPlaceOrientation
{
	// +(instancetype)initPlaceOrientationFacing __attribute__((deprecated("Please use placeOrientationFacing")));
	[Static]
	[Export("initPlaceOrientationFacing")]
	VMEPlaceOrientation InitPlaceOrientationFacing();

	// +(instancetype)placeOrientationFacing;
	[Static]
	[Export("placeOrientationFacing")]
	VMEPlaceOrientation PlaceOrientationFacing();

	// +(instancetype)initPlaceOrientationFlat __attribute__((deprecated("Please use placeOrientationFlat")));
	[Static]
	[Export("initPlaceOrientationFlat")]
	VMEPlaceOrientation InitPlaceOrientationFlat();

	// +(instancetype)placeOrientationFlat;
	[Static]
	[Export("placeOrientationFlat")]
	VMEPlaceOrientation PlaceOrientationFlat();

	// +(instancetype)initPlaceOrientationFixedWithHeading:(float)heading __attribute__((deprecated("Please use placeOrientationFixedWithHeading:")));
	[Static]
	[Export("initPlaceOrientationFixedWithHeading:")]
	VMEPlaceOrientation InitPlaceOrientationFixedWithHeading(float heading);

	// +(instancetype)placeOrientationFixedWithHeading:(float)heading;
	[Static]
	[Export("placeOrientationFixedWithHeading:")]
	VMEPlaceOrientation PlaceOrientationFixedWithHeading(float heading);
}

// @interface VMEPlaceVisibilityRamp : NSObject
[BaseType(typeof(NSObject))]
interface VMEPlaceVisibilityRamp
{
	// -(instancetype)initWithStartVisible:(double)startVisible fullyVisible:(double)fullyVisible startInvisible:(double)startInvisible fullyInVisible:(double)fullyInVisible;
	[Export("initWithStartVisible:fullyVisible:startInvisible:fullyInVisible:")]
	IntPtr Constructor(double startVisible, double fullyVisible, double startInvisible, double fullyInVisible);

	// @property (nonatomic) double startVisible;
	[Export("startVisible")]
	double StartVisible { get; set; }

	// @property (nonatomic) double fullyVisible;
	[Export("fullyVisible")]
	double FullyVisible { get; set; }

	// @property (nonatomic) double startInvisible;
	[Export("startInvisible")]
	double StartInvisible { get; set; }

	// @property (nonatomic) double fullyInvisible;
	[Export("fullyInvisible")]
	double FullyInvisible { get; set; }
}

// @interface VMEPlaceSize : NSObject
[BaseType(typeof(NSObject))]
interface VMEPlaceSize
{
	// -(instancetype)initWithScale:(float)scale;
	[Export("initWithScale:")]
	IntPtr Constructor(float scale);

	// -(instancetype)initWithScale:(float)scale constantSizeDistance:(float)constantSizeDistance;
	[Export("initWithScale:constantSizeDistance:")]
	IntPtr Constructor(float scale, float constantSizeDistance);

	// @property (nonatomic) float constantSizeDistance;
	[Export("constantSizeDistance")]
	float ConstantSizeDistance { get; set; }

	// @property (nonatomic) float scale;
	[Export("scale")]
	float Scale { get; set; }
}

// @protocol VMEPlaceInterface <NSObject>
/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
[Protocol]
[BaseType(typeof(NSObject))]
interface VMEPlaceInterface
{
	// @required -(void)updatePlaceData:(NSDictionary *)data;
	[Abstract]
	[Export("updatePlaceData:")]
	void UpdatePlaceData(NSDictionary data);

	// @required -(BOOL)setPlaceID:(NSString *)placeID data:(NSDictionary *)data;
	[Abstract]
	[Export("setPlaceID:data:")]
	bool SetPlaceID(string placeID, NSDictionary data);

	// @required -(BOOL)setPlaceID:(NSString *)placeID color:(UIColor *)color;
	[Abstract]
	[Export("setPlaceID:color:")]
	bool SetPlaceID(string placeID, UIColor color);

	// @required -(BOOL)resetPlaceIDColor:(NSString *)placeID;
	[Abstract]
	[Export("resetPlaceIDColor:")]
	bool ResetPlaceIDColor(string placeID);

	// @required -(BOOL)addPlaceID:(NSString *)placeID imageURL:(NSURL *)imageURL data:(NSDictionary *)data position:(VMEPosition *)position size:(VMEPlaceSize *)size anchorMode:(VMEPlaceAnchorMode)anchorMode altitudeMode:(VMEPlaceAltitudeMode)altitudeMode displayMode:(VMEPlaceDisplayMode)displayMode orientation:(VMEPlaceOrientation *)orientation visibilityRamp:(VMEPlaceVisibilityRamp *)visibilityRamp;
	[Abstract]
	[Export("addPlaceID:imageURL:data:position:size:anchorMode:altitudeMode:displayMode:orientation:visibilityRamp:")]
	bool AddPlaceID(string placeID, NSUrl imageURL, NSDictionary data, VMEPosition position, VMEPlaceSize size, VMEPlaceAnchorMode anchorMode, VMEPlaceAltitudeMode altitudeMode, VMEPlaceDisplayMode displayMode, VMEPlaceOrientation orientation, VMEPlaceVisibilityRamp visibilityRamp);

	// @required -(BOOL)addPlaceID:(NSString *)placeID imageURL:(NSURL *)imageURL data:(NSDictionary *)data position:(VMEPosition *)position;
	[Abstract]
	[Export("addPlaceID:imageURL:data:position:")]
	bool AddPlaceID(string placeID, NSUrl imageURL, NSDictionary data, VMEPosition position);

	// @required -(BOOL)setPlaceID:(NSString *)placeID position:(VMEPosition *)position animated:(BOOL)animated;
	[Abstract]
	[Export("setPlaceID:position:animated:")]
	bool SetPlaceID(string placeID, VMEPosition position, bool animated);

	// @required -(BOOL)setPlaceID:(NSString *)placeID size:(VMEPlaceSize *)size animated:(BOOL)animated;
	[Abstract]
	[Export("setPlaceID:size:animated:")]
	bool SetPlaceID(string placeID, VMEPlaceSize size, bool animated);

	// @required -(BOOL)removePlaceID:(NSString *)placeID;
	[Abstract]
	[Export("removePlaceID:")]
	bool RemovePlaceID(string placeID);

	// @required -(NSArray *)queryAllPlaceIDs;
	[Abstract]
	[Export("queryAllPlaceIDs")]
	[Verify(MethodToProperty), Verify(StronglyTypedNSArray)]
	NSObject[] QueryAllPlaceIDs { get; }
}

// @protocol VMESearchViewCallback <NSObject>
/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
[Protocol]
[BaseType(typeof(NSObject))]
interface VMESearchViewCallback
{
	// @required -(void)searchView:(VMEMapView *)mapView didSelectPlaceID:(NSString *)placeID;
	[Abstract]
	[Export("searchView:didSelectPlaceID:")]
	void SearchView(VMEMapView mapView, string placeID);

	// @required -(void)searchViewDidCancel:(VMEMapView *)mapView;
	[Abstract]
	[Export("searchViewDidCancel:")]
	void SearchViewDidCancel(VMEMapView mapView);
}

// @protocol VMESearchViewInterface <NSObject>
/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
[Protocol]
[BaseType(typeof(NSObject))]
interface VMESearchViewInterface
{
	// @required -(void)showSearchViewWithTitle:(NSString *)title callback:(id<VMESearchViewCallback>)callback;
	[Abstract]
	[Export("showSearchViewWithTitle:callback:")]
	void Callback(string title, VMESearchViewCallback callback);
}

// @interface VMEMapView : UIView <VMEComputeRouteInterface, VMELocationInterface, VMEMapInterface, VMEOverlayViewInterface, VMEPlaceInterface, VMESearchViewInterface>
[BaseType(typeof(UIView))]
interface VMEMapView : IVMEComputeRouteInterface, IVMELocationInterface, IVMEMapInterface, IVMEOverlayViewInterface, IVMEPlaceInterface, IVMESearchViewInterface
{
	// +(NSString *)getVersion;
	[Static]
	[Export("getVersion")]
	[Verify(MethodToProperty)]
	string Version { get; }

	// +(NSString *)getMinDataSDKVersion;
	[Static]
	[Export("getMinDataSDKVersion")]
	[Verify(MethodToProperty)]
	string MinDataSDKVersion { get; }

	// -(instancetype)initWithFrame:(CGRect)frame;
	[Export("initWithFrame:")]
	IntPtr Constructor(CGRect frame);

	// -(void)loadMap;
	[Export("loadMap")]
	void LoadMap();

	// @property (nonatomic) NSString * mapPath;
	[Export("mapPath")]
	string MapPath { get; set; }

	// @property (nonatomic) NSString * mapSecretCode;
	[Export("mapSecretCode")]
	string MapSecretCode { get; set; }

	// @property (nonatomic) NSString * mapHash;
	[Export("mapHash")]
	string MapHash { get; set; }

	// @property (nonatomic) NSString * mapServerURL;
	[Export("mapServerURL")]
	string MapServerURL { get; set; }

	// @property (nonatomic, weak) id<VMEMapListener> mapListener __attribute__((iboutlet));
	[Export("mapListener", ArgumentSemantic.Weak)]
	VMEMapListener MapListener { get; set; }
}
