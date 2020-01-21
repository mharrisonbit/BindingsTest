/*
 * Copyright 2015, Visioglobe SAS
 * ALL RIGHTS RESERVED
 *
 *
 * LICENSE: Visioglobe grants the user ("Licensee") permission to reproduce,
 * distribute, and create derivative works from this Source Code,
 * provided that: (1) the user reproduces this entire notice within
 * both source and binary format redistributions and any accompanying
 * materials such as documentation in printed or electronic format;
 * (2) the Source Code is not to be used, or ported or modified for
 * use, except in conjunction with Visioglobe SDK; and (3) the
 * names of Visioglobe SAS may not be used in any
 * advertising or publicity relating to the Source Code without the
 * prior written permission of Visioglobe.  No further license or permission
 * may be inferred or deemed or construed to exist with regard to the
 * Source Code or the code base of which it forms a part. All rights
 * not expressly granted are reserved.
 *
 * This Source Code is provided to Licensee AS IS, without any
 * warranty of any kind, either express, implied, or statutory,
 * including, but not limited to, any warranty that the Source Code
 * will conform to specifications, any implied warranties of
 * merchantability, fitness for a particular purpose, and freedom
 * from infringement, and any warranty that the documentation will
 * conform to the program, or any warranty that the Source Code will
 * be error free.
 *
 * IN NO EVENT WILL VISIOGLOBE BE LIABLE FOR ANY DAMAGES, INCLUDING, BUT NOT
 * LIMITED TO DIRECT, INDIRECT, SPECIAL OR CONSEQUENTIAL DAMAGES,
 * ARISING OUT OF, RESULTING FROM, OR IN ANY WAY CONNECTED WITH THE
 * SOURCE CODE, WHETHER OR NOT BASED UPON WARRANTY, CONTRACT, TORT OR
 * OTHERWISE, WHETHER OR NOT INJURY WAS SUSTAINED BY PERSONS OR
 * PROPERTY OR OTHERWISE, AND WHETHER OR NOT LOSS WAS SUSTAINED FROM,
 * OR AROSE OUT OF USE OR RESULTS FROM USE OF, OR LACK OF ABILITY TO
 * USE, THE SOURCE CODE.
 *
 * Contact information:  Visioglobe SAS,
 * 55, rue Blaise Pascal
 * 38330 Monbonnot Saint Martin
 * FRANCE
 * or:  http://www.visioglobe.com
 */
#import <Foundation/Foundation.h>

#pragma mark - VMESearchViewCallback
/**
 * Callback protocol for receiving search view results.  See VMESearchViewInterface
 * for displaying the search view.
 *
 * @version 1.0
 */
@protocol VMESearchViewCallback <NSObject>

/**
 * Notified when a place was selected from the search view
 * @param mapView The map view who received the original request
 * @param placeID The id of the place selected.
 *
 * @version 1.0
 */
-(void) searchView:(VMEMapView*)mapView didSelectPlaceID:(NSString*)placeID;

/**
 * Notified when the search view was cancelled
 * @param mapView The map view who received the original request.
 *
 * @version 1.0
 */
-(void) searchViewDidCancel:(VMEMapView*)mapView;

@end

#pragma mark - VMESearchViewInterface

/**
 * Interface protocol for displaying the search view.
 *
 * @version 1.0
 */
@protocol VMESearchViewInterface <NSObject>

/**
 * Request to show the search view.
 * @param title The title to display within the seach view.
 * @param callback The callback to invoke with the result.  Pass nil if you do
 * not need to be informed of the result.
 *
 * @version 1.0
 *
 * <b>Example</b>
 @code
[self.mapView showSearchViewWithTitle:@"My Title" callback:nil];
 @endcode
 */
-(void) showSearchViewWithTitle:(NSString*) title callback:(id<VMESearchViewCallback>) callback;
@end

