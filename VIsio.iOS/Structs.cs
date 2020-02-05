using ObjCRuntime;

namespace VisioMoveEssential
{
	[Native]
	public enum VMERouteRequestType : long
	{
		Shortest,
		Fastest
	}

	[Native]
	public enum VMERouteDestinationsOrder : long
	{
		InOrder,
		Optimal,
		OptimalFinishOnLast,
		Closest
	}

	[Native]
	public enum VMEViewMode : long
	{
		Global,
		Floor,
		Unknown
	}

	[Native]
	public enum VMEPlaceAnchorMode : long
	{
		TopLeft,
		TopCenter,
		TopRight,
		CenterLeft,
		Center,
		CenterRight,
		BottomLeft,
		BottomCenter,
		BottomRight
	}

	[Native]
	public enum VMEPlaceAltitudeMode : long
	{
		Relative,
		Absolute
	}

	[Native]
	public enum VMEPlaceDisplayMode : long
	{
		Inlay,
		Overlay
	}
}
