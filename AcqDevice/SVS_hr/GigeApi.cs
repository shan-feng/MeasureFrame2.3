/*******************************************************************************
 * SVS GigE API   Declaration of GigE camera access functions
 *******************************************************************************
 *
 * Version:     1.5.0.177 / December 2013 
 *
 * Copyright:   SVS VISTEK GmbH
 *
 *******************************************************************************
 *
 * Function categories:
 * ---------------------------------------------------------
 *    1 - Camera: Discovery and bookkeeping
 *    2 - Camera: Connection
 *    3 - Camera: Information
 *    4 - Stream: Channel creation and control
 *    5 - Stream: Channel statistics
 *    6 - Stream: Channel info
 *    7 - Stream: Transfer parameters
 *    8 - Stream: Image access
 *    9 - Stream: Image conversion
 *   10 - Stream: Image characteristics
 *   11 - Stream: Image statistics
 *   12 - Stream: Messaging channel
 *   13 - Controlling camera: Frame rate
 *   14 - Controlling camera: Exposure
 *   15 - Controlling camera: Gain and offset
 *   16 - Controlling camera: Auto gain/exposure
 *   17 - Controlling camera: Acquisition trigger
 *   18 - Controlling camera: Strobe
 *   19 - Controlling camera: Tap balance
 *   20 - Controlling camera: Image parameter
 *   21 - Controlling camera: Image appearance
 *   22 - Special control: IOMux configuration
 *   23 - Special control: IO control
 *   24 - Special control: Serial communication
 *   25 - Special control: Direct register and memory access
 *   26 - Special control: Persistent settings and recovery
 *   27 - General functions
 *   28 - Diagnostics
 * ---------------------------------------------------------
 *   99 - Deprecated functions
 *
 *******************************************************************************
 *
 * Revision history:
 * Version 1.4.24.59
 * -----------------
 *   - functions added:
 *     + Camera_getSensorTemperature()
 *     + Camera_setPivMode()
 *     + Camera_getPivMode()
 *     + Camera_setPrescalerDevisor()
 *     + Camera_getPrescalerDevisor()
 *     + Camera_setDebouncerDuration()
 *     + Camera_getDebouncerDuration()
 *     + Camera_loadSequenceParameters()
 *     + Camera_startSequencer()
 *     + Camera_setStrobePolarityExtended()
 *     + Camera_getStrobePolarityExtended()
 *     + Camera_setStrobePositionExtended()
 *     + Camera_getStrobePositionExtended()
 *     + Camera_getStrobePositionIncrement()
 *     + Camera_setStrobeDurationExtended()
 *     + Camera_getStrobeDurationExtended()
 *     + Camera_getTapGain()
 *     + Camera_setTapGain()
 *     + Camera_loadSettingsFromXml()  
 *     + Camera_SaveSettingsToXml()  
 *     + Camera_loadSequenceParameters()
 *     + Camera_startSequencer()
 *   - removed
 *     - Camera_setUserTapGain()
 *     - Camera_getUserTapGain()
 *
 * Version 1.4.24.58
 * -----------------
 *   - firmware for 'eco' camera series updated to build 1759 with support for 'trigger violation' 
 *
 * Version 1.4.24.57
 * -----------------
 *   - messages from camera added, like e.g. "trigger violation"
 *   - signals 9/10 exchanged for TL consistency ("camera found"/"multicast message")
 *   - GEV(GigE Vision) return codes properly translated into GigE_GEV_ codes (-301..-314)
 *   - custom GEV codes translated to GigE_SVCAM_STATUS_ codes (-130..-132,-140..-145)
 *   - functions added:
 *		 + Camera_startImageCorrection()
 *     + Camera_isIdleImageCorrection()
 *     + Camera_setImageCorrection()
 *     + Camera_getImageCorrection()
 *     + Camera_setTapUserSettings()
 *     + Camera_getTapUserSettings()
 *   - functions deprecated
 *     - Camera_setTapBalance()
 *     - Camera_getTapBalance()
 *   - "MultiStream" (removed)->deprecated
 *
 * Version 1.4.23.56
 * -----------------
 *   - functions deprecated
 *		 - Image_getImageGray()
 *     - StreamingChannel_createMultiStream()
 *     - Camera_forceOpenConnection()
 *
 * Version 1.4.23.55
 * -----------------
 *   - functions added:
 *     + isDriverAvailable()
 *
 * Version 1.4.23.54
 * -----------------
 *  - frame rate (color) increased by removing performance bottlenecks
 *  - naming consistency improved: SVGige_ to SVGigE_
 * 
 * 
 *******************************************************************************
 * Detailed function listing
 *******************************************************************************
 *
 * 0 - GigE DLL (implicitly called)
 * ---------------------------------
 *  isVersionCompliantDLL()
 *  isLoadedGigEDLL()
 *  getCamera()
 *
 * 1 - Camera: Discovery and bookkeeping
 * -------------------------------------
 *  CameraContainer_create()
 *  CameraContainer_delete()
 *  CameraContainer_discovery()
 *  CameraContainer_getNumberOfCameras()
 *  CameraContainer_getCamera()
 *  CameraContainer_findCamera()
 *	
 * 2 - Camera: Connection
 * ----------------------
 *  Camera_openConnection()
 *  Camera_closeConnection()
 *  Camera_setIPAddress()
 *  Camera_forceValidNetworkSettings() 
 *  Camera_restartIPConfiguration() 
 *
 * 3 - Camera: Information
 * ----------------------
 *  Camera_getManufacturerName()
 *  Camera_getModelName()
 *  Camera_getDeviceVersion()
 *  Camera_getManufacturerSpecificInformation()
 *  Camera_getSerialNumber()
 *  Camera_setUserDefinedName()
 *  Camera_getUserDefinedName()
 *  Camera_getMacAddress()
 *  Camera_getIPAddress()
 *  Camera_getSubnetMask()
 *  Camera_getPixelClock()
 *  Camera_isCameraFeature()
 *  Camera_readXMLFile()
 *  Camera_getSensorTemperature() 
 *
 * 4 - Stream: Channel creation and control
 * ----------------------------------------
 *  StreamingChannel_create()
 *  StreamingChannel_createMultiStream()
 *  StreamingChannel_delete()
 *  StreamingChannel_setChannelTimeout()
 *  StreamingChannel_getChannelTimeout()
 *  StreamingChannel_setReadoutTransfer()
 *  StreamingChannel_getReadoutTransfer()
 *
 * 5 - Stream: Channel statistics
 * ------------------------------------------
 *  StreamingChannel_getFrameLoss()
 *  StreamingChannel_getActualFrameRate()
 *  StreamingChannel_getActualDataRate()
 *  StreamingChannel_getPeakDataRate()
 * 
 * 6 - Stream: Channel info
 * ------------------------
 *  StreamingChannel_getPixelType()
 *  StreamingChannel_getBufferData()
 *  StreamingChannel_getBufferSize()
 *  StreamingChannel_getImagePitch()
 *  StreamingChannel_getImageSizeX()
 *  StreamingChannel_getImageSizeY()
 *
 * 7 - Stream: Transfer parameters
 * -------------------------------
 *  Camera_evaluateMaximalPacketSize()
 *  Camera_setStreamingPacketSize()
 *  Camera_setInterPacketDelay()
 *  Camera_getInterPacketDelay()
 *  Camera_setMulticastMode()
 *  Camera_getMulticastMode()
 *  Camera_getMulticastGroup()
 *
 * 8 - Stream: Image access
 * ------------------------
 *  Image_getDataPointer()
 *  Image_getBufferIndex()
 *  Image_getSignalType()
 *  Image_getCamera()
 *  Image_release()
 *
 * 9 - Stream: Image conversion
 * ----------------------------
 *  Image_getImageRGB()
 *  Image_getImageGray()
 *  Image_getImage12bitAs8bit()
 *  Image_getImage12bitAs16bit()
 *  Image_getImage16bitAs8bit()
 *		
 * 10 - Stream: Image characteristics
 * ----------------------------------
 *  Image_getPixelType()
 *  Image_getImageSize()
 *  Image_getPitch()
 *  Image_getSizeX()
 *  Image_getSizeY()
 *
 * 11 - Stream: Image statistics
 * ----------------------------
 *  Image_getImageID()
 *  Image_getTimestamp()
 *  Image_getTransferTime()
 *  Image_getPacketCount()
 *  Image_getPacketResend()
 *
 * 12 - Stream: Messaging channel
 * ------------------------------
 *  Stream_createEvent()
 *  Stream_addMessageType()
 *  Stream_removeMessageType()
 *  Stream_isMessagePending()
 *  Stream_registerEventCallback()
 *  Stream_unregisterEventCallback()
 *  Stream_getMessage()
 *  Stream_getMessageData()
 *  Stream_getMessageTimestamp()
 *  Stream_releaseMessage()
 *  Stream_flushMessages()
 *  Stream_closeEvent()
 *  
 * 13 - Controlling camera: Frame rate
 * -----------------------------------
 *  Camera_setFrameRate()
 *  Camera_getFrameRate()
 *  Camera_getFrameRateMin()
 *  Camera_getFrameRateMax()
 *  Camera_getFrameRateRange()
 *  Camera_getFrameRateIncrement()
 *
 * 14 - Controlling camera: Exposure
 * ---------------------------------
 *  Camera_setExposureTime()
 *  Camera_getExposureTime()
 *  Camera_getExposureTimeMin()
 *  Camera_getExposureTimeMax()
 *  Camera_getExposureTimeRange()
 *  Camera_getExposureTimeIncrement()
 *  Camera_setExposureDelay()
 *  Camera_getExposureDelay()
 *  Camera_getExposureDelayMax()
 *  Camera_getExposureDelayIncrement()
 *
 * 15 - Controlling camera: Gain and offset
 * ----------------------------------------
 *  Camera_setGain()
 *  Camera_getGain()
 *  Camera_getGainMax()
 *  Camera_getGainMaxExtended()
 *  Camera_getGainIncrement()
 *  Camera_setOffset()
 *  Camera_getOffset()
 *  Camera_getOffsetMax()
 *
 * 16 - Controlling camera: Auto gain/exposure
 * -------------------------------------------
 *  Camera_setAutoGainEnabled()
 *  Camera_getAutoGainEnabled()
 *  Camera_setAutoGainBrightness()
 *  Camera_getAutoGainBrightness()
 *  Camera_setAutoGainDynamics()
 *  Camera_getAutoGainDynamics()
 *  Camera_setAutoGainLimits()
 *  Camera_getAutoGainLimits()
 *  Camera_setAutoExposureLimits()
 *  Camera_getAutoExposureLimits()
 *
 * 17 - Controlling camera: Acquisition trigger
 * --------------------------------------------
 *  Camera_setAcquisitionControl()
 *  Camera_getAcquisitionControl()
 *  Camera_setAcquisitionMode()
 *  Camera_setAcquisitionModeAndStart()
 *  Camera_getAcquisitionMode()
 *  Camera_softwareTrigger()
 *  Camera_softwareTriggerID()
 *  Camera_softwareTriggerIDEnable()
 *  Camera_setTriggerPolarity()
 *  Camera_getTriggerPolarity()
 *  Camera_setPivMode()
 *  Camera_getPivMode()
 *  Camera_setDebouncerDuration()
 *  Camera_getDebouncerDuration()
 *  Camera_setPrescalerDevisor()
 *  Camera_getPrescalerDevisor()
 *  Camera_loadSequenceParameters()
 *  Camera_startSequencer()
 *
 * 18 - Controlling camera: Strobe
 * -------------------------------
 *  Camera_setStrobePolarity()
 *  Camera_setStrobePolarityExtended()
 *  Camera_getStrobePolarity()
 *  Camera_getStrobePolarityExtended()
 *  Camera_setStrobePosition()
 *  Camera_setStrobePositionExtended()
 *  Camera_getStrobePosition()
 *  Camera_getStrobePositionExtended()
 *  Camera_getStrobePositionMax()
 *  Camera_getStrobePositionIncrement()
 *  Camera_setStrobeDuration()
 *  Camera_setStrobeDurationExtended()
 *  Camera_getStrobeDuration()
 *  Camera_getStrobeDurationExtended()
 *  Camera_getStrobeDurationMax()
 *  Camera_getStrobeDurationIncrement()
 *
 * 19 - Controlling camera: Tap balance
 * ------------------------------------
 *  Camera_saveTapBalanceSettings()
 *  Camera_loadTapBalanceSettings()
 *  Camera_setTapConfiguration()
 *  Camera_getTapConfiguration()
 *  Camera_setAutoTapBalanceMode()
 *  Camera_getAutoTapBalanceMode()
 *  Camera_setTapBalance()
 *  Camera_getTapBalance()
 *  Camera_setTapGain()
 *  Camera_getTapGain()
 *
 * 20 - Controlling camera: Image parameter
 * ---------------------------------------
 *  Camera_getImagerWidth()
 *  Camera_getImagerHeight()
 *  Camera_getImageSize()
 *  Camera_getPitch()
 *  Camera_getSizeX()
 *  Camera_getSizeY()
 *  Camera_setBinningMode()
 *  Camera_getBinningMode()
 *  Camera_setAreaOfInterest()
 *  Camera_getAreaOfInterest()
 *  Camera_getAreaOfInterestRange()
 *  Camera_getAreaOfInterestIncrement()
 *  Camera_resetTimestampCounter()
 *  Camera_getTimestampCounter()
 *  Camera_getTimestampTickFrequency()
 *
 * 21 - Controlling camera: Image appearance
 * -----------------------------------------
 *  Camera_getPixelType()
 *  Camera_setPixelDepth()
 *  Camera_getPixelDepth()
 *  Camera_setWhiteBalance()
 *  Camera_getWhiteBalance()
 *  Camera_getWhiteBalanceMax()
 *  Camera_setGammaCorrection()
 *  Camera_setLowpassFilter()
 *  Camera_getLowpassFilter()
 *  Camera_setLookupTableMode()
 *  Camera_getLookupTableMode()
 *  Camera_setLookupTable()
 *  Camera_getLookupTable()
 *
 * 22 - Special control: IOMux configuration
 * -------------------------------------------------------
 *  Camera_getMaxIOMuxIN()
 *  Camera_getMaxIOMuxOUT()
 *  Camera_setIOAssignment()
 *  Camera_getIOAssignment()
 *
 * 23 - Special control: IO control
 * -------------------------------------------------------
 *  Camera_setIOMuxIN()
 *  Camera_getIOMuxIN()
 *  Camera_setIO()
 *  Camera_getIO()
 *  Camera_setAcqLEDOverride()
 *  Camera_getAcqLEDOverride()
 *  Camera_setLEDIntensity()
 *  Camera_getLEDIntensity()
 *
 * 24 - Special control: Serial communication
 * -------------------------------------------------------
 *  Camera_setUARTBuffer()
 *  Camera_getUARTBuffer()
 *  Camera_setUARTBaud()
 *  Camera_getUARTBaud()
 *
 * 25 - Special control: Direct register and memory access
 * -------------------------------------------------------
 *  Camera_setGigECameraRegister()
 *  Camera_getGigECameraRegister()
 *  Camera_writeGigECameraMemory()
 *  Camera_readGigECameraMemory()
 *  Camera_forceOpenConnection()
 *
 * 26 - Special control: Persistent settings and recovery
 * ------------------------------------------------------
 *  Camera_writeEEPROM()
 *  Camera_readEEPROM()
 *  Camera_restoreFactoryDefaults()
 *  Camera_loadSettingsFromXml()  
 *  Camera_SaveSettingsToXml()  
 *
 * 27 - General functions
 * ----------------------
 *  SVGigE_estimateWhiteBalance()
 *  SVGigE_writeImageToBitmapFile()
 *  SVGigE_installFilterDriver()
 *  SVGigE_uninstallFilterDriver()
 *
 * 28 - Diagnostics
 * ----------------
 *  getErrorMessage()
 *  Camera_registerForLogMessages()
 *
 * ---------------------------------------------------------
 * 99 - Deprecated functions
 * ---------------------------------------------------------
 *  Camera_startAcquisitionCycle()
 *  Camera_setTapCalibration()
 *  Camera_getTapCalibration()
 *  Camera_setLUTMode()
 *  Camera_getLUTMode()
 *  Camera_createLUTwhiteBalance()
 *  Camera_stampTimestamp()
 *  Camera_getTimestamp()
 *  Image_getImageGray()
 *  Camera_forceOpenConnection()
 *  StreamingChannel_createMultiStream()
 *  Camera_setTapBalance()
 *  Camera_getTapBalance()
 *
 *******************************************************************************/

#define X64
using System;
using System.Runtime.InteropServices;
using System.Text;

namespace AcqDevice
{

    /// <summary>
    /// GigeApi.
    /// </summary>
    [Serializable]
    public class GigeApi
    {
        /** SVGgiE DLL
         *  Dependent on system platform a 32-bit or 64-bit version of SVGigE.dll will be loaded
         */
#if X64
        const string SVGigE_DLL = "SVGigE.x64.dll";
#else
        const string SVGigE_DLL = "SVGigE.dll";
#endif


        /** Version information
   *  The particular components of the version information will be represented
   *  in the following way
   */
        /* TODO: Find out how to declare struct in C# compliant to C++
       typedef struct
       {
         unsigned char	MajorVersion;
         unsigned char MinorVersion;
         unsigned char	DriverVersion;
         unsigned char	BuildVersion;

       } SVGigE_VERSION; 
     */

        /** Camera Container client handle.
         *  A camera container client handle serves as a reference for managing multiple
         *  clients that are connected to a single camera container (which has no notion
         *  about clients). A value of SVGigE_NO_CLIENT serves as an indicator for
         *  an invalid camera container client before obtaining a valid handle.
         */
        public const int SVGigE_NO_CLIENT = -1;

        /** Camera handle.
         *  A camera handle serves as a reference for access functions to camera
         *  functionality. A value of SVGigE_NO_CAMERA serves as an indicator for an
         *  invalid camera handle before obtaining a camera from a camera container.
         */
        public const int SVGigE_NO_CAMERA = -1;

        /** Streaming channel handle.
         *  A streaming channel handle serves as a reference for an image stream
         */
        public const int SVGigE_NO_STREAMING_CHANNEL = -1;

        /** Event handle.
         *  An event handle serves as a reference for a messaging channel
         */
        public const int SVGigE_NO_EVENT = -1;

        /** Message handle.
         *  A message handle serves as a reference for a single message
         */
        public const int SVGigE_NO_MESSAGE = -1;


        // Ver. 1.4.16.40                   
        // Indicate if pixel is monochrom or RGB
        public const uint GVSP_PIX_MONO = 0x01000000;
        public const uint GVSP_PIX_RGB = 0x02000000;

        // Indicate effective number of bits occupied by the pixel (including padding).
        // This can be used to compute amount of memory required to store an image.
        public const uint GVSP_PIX_OCCUPY8BIT = 0x00080000;
        public const uint GVSP_PIX_OCCUPY12BIT = 0x000C0000;
        public const uint GVSP_PIX_OCCUPY16BIT = 0x00100000;
        public const uint GVSP_PIX_OCCUPY24BIT = 0x00180000;

        // Bit masks 
        public const uint GVSP_PIX_COLOR_MASK = 0xFF000000;
        public const uint GVSP_PIX_EFFECTIVE_PIXELSIZE_MASK = 0x00FF0000;
        public const uint GVSP_PIX_ID_MASK = 0x0000FFFF;

        // Bit shift value
        public const uint GVSP_PIX_EFFECTIVE_PIXELSIZE_SHIFT = 16;



        public const uint GVPC_USER_SPACE_SENSORDATA = 0xA800;
        public const uint GVPC_USER_SPACE_SENSORDATA_STORE = GVPC_USER_SPACE_SENSORDATA + 8;
        public const uint GVPC_USER_SPACE_SENSORDATA_GAIN_0DB_LEFT = GVPC_USER_SPACE_SENSORDATA + 12;
        public const uint GVPC_USER_SPACE_SENSORDATA_OFFSET_LEFT = GVPC_USER_SPACE_SENSORDATA + 16;
        public const uint GVPC_USER_SPACE_SENSORDATA_GAIN_0DB_RIGHT = GVPC_USER_SPACE_SENSORDATA + 20;
        public const uint GVPC_USER_SPACE_SENSORDATA_OFFSET_RIGHT = GVPC_USER_SPACE_SENSORDATA + 24;

        public const uint GVPC_USER_SPACE_CAMMODE = 0xA300;

        public const uint GVPC_USER_SPACE_CAMMMODE_ADCGAIN = GVPC_USER_SPACE_CAMMODE + 72;
        public const uint GVPC_USER_SPACE_CAMMMODE_ADCOFFSET = GVPC_USER_SPACE_CAMMODE + 76;

        public const uint GIGE_CAMERA_ACCESS_KEY = 42;



        /** Function returns.
        *  API Functions may return success or error codes by this data type unless
        *  they return specific values
        */
        public enum SVSGigeApiReturn : int
        {
            SVGigE_SUCCESS = 0,
            SVGigE_ERROR = -1,
            SVGigE_DLL_NOT_LOADED = -2,
            SVGigE_DLL_VERSION_MISMATCH = -3,
            SVGigE_DRIVER_VERSION_MISMATCH = -4,
            SVGigE_WINSOCK_INITIALIZATION_FAILED = -5,
            SVGigE_CAMERA_CONTAINER_NOT_AVAILABLE = -6,
            SVGigE_NO_CAMERAS_DETECTED = -7,
            SVGigE_CAMERA_NOT_FOUND = -8,
            SVGigE_CAMERA_OPEN_FAILED = -9,
            SVGigE_CAMERA_COMMUNICATION_FAILED = -10,
            SVGigE_CAMERA_REGISTER_ACCESS_DENIED = -11,
            SVGigE_UNKNOWN_LUT_MODE = -12,
            SVGigE_STREAMING_FUNCTION_ALREADY_REGISTERED = -13,
            SVGigE_STREAMING_NOT_INITIALIZED = -14,
            SVGigE_OUT_OF_MEMORY = -15,
            SVGigE_INVALID_CALLBACK_INITIALIZATION = -16,
            SVGigE_INVALID_CALLBACK_FUNCTION_POINTER = -17,
            SVGigE_IMAGE_NOT_AVAILABLE = -18,
            SVGigE_INSUFFICIENT_RGB_BUFFER_PROVIDED = -19,
            SVGigE_STREAMING_CHANNEL_NOT_AVAILABLE = -20,
            SVGigE_INVALID_PARAMETERS = -21,
            SVGigE_PIXEL_TYPE_NOT_SUPPORTED = -22,
            SVGigE_FILE_COULD_NOT_BE_OPENED = -23,
            SVGigE_TRANSPORT_LAYER_NOT_AVAILABLE = -24,
            SVGigE_XML_FILE_NOT_AVAILABLE = -25,
            SVGigE_WHITE_BALANCE_FAILED = -26,
            SVGigE_DEPRECATED_FUNCTION = -27,
            SVGigE_WRONG_DESTINATION_BUFFER_SIZE = -28,
            SVGigE_INSUFFICIENT_DESTINATION_BUFFER_SIZE = -29,
            SVGigE_CAMERA_NOT_IN_CURRENT_SUBNET = -30,
            SVGigE_CAMERA_MOVED_TO_FOREIGN_SUBNET = -31,
            SVGigE_IMAGE_SKIPPED_IN_CALLBACK = -32,

            // Mapped camera return codes
            SVGigE_SVCAM_STATUS_ERROR = -101,
            SVGigE_SVCAM_STATUS_SOCKET_ERROR = -102,
            SVGigE_SVCAM_STATUS_ALREADY_CONNECTED = -103,
            SVGigE_SVCAM_STATUS_INVALID_MAC = -104,
            SVGigE_SVCAM_STATUS_UNREACHABLE = -105,
            SVGigE_SVCAM_STATUS_ACCESS_DENIED = -106,
            SVGigE_SVCAM_STATUS_BUSY = -107,
            SVGigE_SVCAM_STATUS_LOCAL_PROBLEM = -108,
            SVGigE_SVCAM_STATUS_MSG_MISMATCH = -109,
            SVGigE_SVCAM_STATUS_PROTOCOL_ID_MISMATCH = -110,
            SVGigE_SVCAM_STATUS_NOT_ACKNOWLEDGED = -111,
            SVGigE_SVCAM_STATUS_RECEIVE_LENGTH_MISMATCH = -112,
            SVGigE_SVCAM_STATUS_ACKNOWLEDGED_LENGTH_MISMATCH = -113,
            SVGigE_SVCAM_STATUS_NO_ACK_BUFFER_PROVIDED = -114,
            SVGigE_SVCAM_STATUS_CONNECTION_LOST = -115,
            SVGigE_SVCAM_STATUS_TL_NOT_AVAILABLE = -116,
            SVGigE_SVCAM_STATUS_DRIVER_VERSION_MISMATCH = -117,
            SVGigE_SVCAM_STATUS_FEATURE_NOT_SUPPORTED = -118,
            SVGigE_SVCAM_STATUS_PENDING_CHANNEL_DETECTED = -119,
            SVGigE_SVCAM_STATUS_LUT_NOT_AVAILABLE = -120,
            SVGigE_SVCAM_STATUS_LUT_SIZE_MISMATCH = -121,
            SVGigE_SVCAM_STATUS_NO_MATCHING_IP_ADDRESS = -122,
            SVGigE_SVCAM_STATUS_DISCOVERY_INFO_CHANGED = -123,
            SVGigE_SVCAM_STATUS_FIRMWARE_UPGRADE_REQUIRED = -124,
            SVGigE_SVCAM_STATUS_MULTICAST_NOT_SUPPORTED = -125,
            SVGigE_SVCAM_STATUS_PIXELDEPTH_NOT_SUPPORTED = -126,
            SVGigE_SVCAM_STATUS_IO_CONFIG_NOT_SUPPORTED = -127,
            SVGigE_SVCAM_STATUS_USER_DEFINED_NAME_TOO_LONG = -128,
            SVGigE_SVCAM_STATUS_INVALID_RESULT_POINTER = -129,
            SVGigE_SVCAM_STATUS_ARP_REQUEST_FAILED = -130,
            SVGigE_SVCAM_STATUS_ALREADY_STREAMING = -131,
            SVGigE_SVCAM_STATUS_NO_STREAMING_CHANNEL = -132,
            SVGigE_SVCAM_STATUS_CAMERA_OCCUPIED = -133,
            SVGigE_SVCAM_STATUS_SECOND_LINK_MISSING = -134,
            SVGigE_SVCAM_STATUS_CAMERA_NOT_CONNECTED = -135,
            SVGigE_SVCAM_STATUS_FILTER_DRIVER_NOT_AVAILABLE = -136,
            SVGigE_SVCAM_STATUS_FILTER_INF_FILE_NOT_FOUND = -137,
            SVGigE_SVCAM_STATUS_FILTER_INF_FILE_COPY_FAILED = -138,
            SVGigE_SVCAM_STATUS_BINNING_MODE_NOT_AVAILABLE = -139,

            SVGigE_SVCAM_STATUS_CAMERA_COMMUNICATION_ERROR = -199,

            // Mapped transport layer return codes
            SVGigE_TL_SUCCESS = 0,
            SVGigE_TL_DLL_NOT_LOADED = -201,
            SVGigE_TL_DLL_VERSION_MISMATCH = -202,
            SVGigE_TL_DLL_ALIGNMENT_PROBLEM = -203,
            SVGigE_TL_OPERATING_SYSTEM_NOT_SUPPORTED = -204,
            SVGigE_TL_WINSOCK_INITIALIZATION_FAILED = -205,
            SVGigE_TL_CAMERA_NOT_FOUND = -206,
            SVGigE_TL_CAMERA_OPEN_FAILED = -207,
            SVGigE_TL_CAMERA_NOT_OPEN = -208,
            SVGigE_TL_CAMERA_UNKNWON_COMMAND = -209,
            SVGigE_TL_CAMERA_PAYLOAD_LENGTH_EXCEEDED = -210,
            SVGigE_TL_CAMERA_PAYLOAD_LENGTH_INVALID = -211,
            SVGigE_TL_CAMERA_COMMUNICATION_TIMEOUT = -212,
            SVGigE_TL_CAMERA_ACCESS_DENIED = -213,
            SVGigE_TL_CAMERA_CONNECTION_LOST = -214,
            SVGigE_TL_STREAMING_FUNCTION_ALREADY_REGISTERED = -215,
            SVGigE_TL_NO_STREAMING_PORT_FOUND = -216,
            SVGigE_TL_OUT_OF_MEMORY = -217,
            SVGigE_TL_INVALID_CALLBACK_FUNCTION_POINTER = -218,
            SVGigE_TL_STREAMING_CHANNEL_NOT_AVAILABLE = -219,
            SVGigE_TL_STREAMING_CHANNEL_VERSION_MISMATCH = -220,
            SVGigE_TL_CALLBACK_INVALID_PARAMETER = -221,
            SVGigE_TL_CALLBACK_IMAGE_DATA_MISSING = -222,
            SVGigE_TL_OPENING_STREAMING_CHANNEL_FAILED = -223,
            SVGigE_TL_CHANNEL_CREATION_FAILED = -224,
            SVGigE_TL_DRIVER_NOT_INSTALLED = -225,
            SVGigE_TL_PENDING_CHANNEL_DETECTED = -226,
            SVGigE_TL_UNSUPPORTED_PACKET_FORMAT = -227,
            SVGigE_TL_INCORRECT_BLOCK_ID = -228,
            SVGigE_TL_INVALID_PARAMETER = -229,
            SVGigE_TL_STREAMING_CHANNEL_LOOSING_FRAMES = -230,
            SVGigE_TL_FRAME_BUFFER_ALLOCATION_FAILED = -231,
            SVGigE_TL_FRAME_BUFFER_INFO_NOT_AVAILABLE = -232,
            SVGigE_TL_MULTICAST_MANAGEMENT_FAILED = -233,
            SVGigE_TL_CAMERA_SIGNAL_IGNORED = -234,
            SVGigE_TL_FILTER_DRIVER_INSTALLATION_NOT_SUPPORTED = -235,
            SVGigE_TL_FILTER_DRIVER_NOT_AVAILABLE = -236,
            SVGigE_TL_FILTER_INF_FILE_NOT_FOUND = -237,
            SVGigE_TL_FILTER_INF_FILE_COPY_FAILED = -238,
            SVGigE_TL_FILTER_INITIALIZING_COM_FAILED = -239,
            SVGigE_TL_FILTER_DRIVER_INSTALLATION_FAILED = -240,
            SVGigE_TL_FILTER_DRIVER_DEINSTALLATION_FAILED = -241,
            SVGigE_TL_DRIVER_INSTALL_REQUIRES_ADMIN_PRIVILEGES = -242,

            // Mapped GEV return codes
            SVGigE_GEV_STATUS_NOT_IMPLEMENTED = -301,
            SVGigE_GEV_STATUS_INVALID_PARAMETER = -302,
            SVGigE_GEV_STATUS_INVALID_ADDRESS = -303,
            SVGigE_GEV_STATUS_WRITE_PROTECT = -304,
            SVGigE_GEV_STATUS_BAD_ALIGNMENT = -305,
            SVGigE_GEV_STATUS_ACCESS_DENIED = -306,
            SVGigE_GEV_STATUS_BUSY = -307,
            SVGigE_GEV_STATUS_LOCAL_PROBLEM = -308,
            SVGigE_GEV_STATUS_MSG_MISMATCH = -309,
            SVGigE_GEV_STATUS_INVALID_PROTOCOL = -310,
            SVGigE_GEV_STATUS_NO_MSG = -311,
            SVGigE_GEV_STATUS_PACKET_UNAVAILABLE = -312,
            SVGigE_GEV_STATUS_DATA_OVERRUN = -313,
            SVGigE_GEV_STATUS_INVALID_HEADER = -314,
            SVGigE_GEV_STATUS_ERROR = -399,

            // Mapped MessagingChannel return codes
            SVGigE_MC_MESSAGING_CHANNEL_NOT_AVAILABLE = -400,
            SVGigE_MC_BUFFER_OVERRUN = -401,
            SVGigE_MC_MEMORY_PROBLEM = -402,
            SVGigE_MC_EVENT_NOT_FOUND = -403,
            SVGigE_MC_MESSAGE_TYPE_EVENT_NOT_FOUND = -404,
            SVGigE_MC_MESSAGE_TYPE_EVENT_EXISTS_ALREADY = -405,
            SVGigE_MC_MESSAGE_PENDING = -406,
            SVGigE_MC_MESSAGE_TIMEOUT = -407,
            SVGigE_MC_MESSAGE_QUEU_EMPTY = -408,
            SVGigE_MC_MESSAGE_EVENT_ERROR = -409,
            SVGigE_MC_MESSAGE_ID_MISMATCH = -410,
            SVGigE_MC_CALLBACK_INVALID = -411,
            SVGigE_MC_CALLBACK_NOT_REGISTERED = -412,
            SVGigE_MC_CALLBACK_REGISTERED_ALREADY = -413,
            SVGigE_MC_CALLBACK_THREAD_NOT_RUNNING = -414,
            SVGigE_MC_CALLBACK_THREAD_STILL_RUNNING = -415,

        }

        public enum SVGigETL_Type : int
        {
            SVGigETL_TypeNone = 0,
            SVGigETL_TypeFilter = 1,
            SVGigETL_TypeWinSock = 2,
            SVGigETL_TypeLinuxKmod = 3,    // loadable kernel module on Linux platforms
            SVGigETL_TypeLinuxSocket = 4,    // sockets availabel on Linux platforms
        }

        /** Camera feature information.         
         *  A camera can support several items from the following set of camera features.
         */
        public enum CAMERA_FEATURE : uint
        {
            CAMERA_FEATURE_SOFTWARE_TRIGGER = 0,  // camera can be triggered by software
            CAMERA_FEATURE_HARDWARE_TRIGGER = 1,  // hardware trigger supported as well as trigger polarity
            CAMERA_FEATURE_HARDWARE_TRIGGER_EXTERNAL_EXPOSURE = 2,  // hardware trigger with internal exposure supported as well as trigger polarity
            CAMERA_FEATURE_FRAMERATE_IN_FREERUNNING_MODE = 3,  // framerate can be adjusted (in free-running mode)
            CAMERA_FEATURE_EXPOSURE_TIME = 4,  // exposure time can be adjusted
            CAMERA_FEATURE_EXPOSURE_DELAY = 5,  // exposure delay can be adjusted
            CAMERA_FEATURE_STROBE = 6,  // strobe is supported (polarity, duration and delay)
            CAMERA_FEATURE_AUTOGAIN = 7,  // autogain is supported
            CAMERA_FEATURE_ADCGAIN = 8,  // 2009-05-15/deprecated
            CAMERA_FEATURE_GAIN = 8,  // the ADC's gain can be adjusted
            CAMERA_FEATURE_AOI = 9,  // image acquisition can be done for an AOI (area of interest)
            CAMERA_FEATURE_BINNING = 10, // binning is supported
            CAMERA_FEATURE_UPDATE_REGISTER = 11, // streaming channel related registers can be pre-set and then updated at once (e.g. for changing an AOI)
            CAMERA_FEATURE_NOT_USED = 12, // not in use
            CAMERA_FEATURE_COLORDEPTH_8BPP = 13, // a pixel depth of 8bit is supported
            CAMERA_FEATURE_COLORDEPTH_10BPP = 14, // a pixel depth of 10bit is supported
            CAMERA_FEATURE_COLORDEPTH_12BPP = 15, // a pixel depth of 12bit is supported
            CAMERA_FEATURE_COLORDEPTH_16BPP = 16, // a pixel depth of 16bit is supported
            CAMERA_FEATURE_ADCOFFSET = 17, // the ADC's offset can be adjusted
            CAMERA_FEATURE_SENSORDATA = 18, // the camera's sensor/ADC settings can be adjusted (the factory settings)
            CAMERA_FEATURE_WHITEBALANCE = 19, // a LUT for whitebalancing is available
            CAMERA_FEATURE_LUT_10TO8 = 20, // a LUT from 10 bit to 8 bit is available
            CAMERA_FEATURE_LUT_12TO8 = 21, // a LUT from 12 bit to 8 bit is available
            CAMERA_FEATURES_FLAGS = 22, // streaming state and image availability can be queried from camera
            CAMERA_FEATURES_READOUT_CONTROL = 23, // time of image read out from camera can be controlled by application
            CAMERA_FEATURES_TAP_CONFIG = 24, // the tap configuration can be changed (switching between one and two taps)
            CAMERA_FEATURES_ACQUISITION = 25, // acquisition can be controlled by start/stop
            CAMERA_FEATURES_TAPBALANCE = 26, // camera is capable of running auto tap balance
            CAMERA_FEATURES_BINNING_V2 = 27, // camera offers extended binning modes
            CAMERA_FEATURES_ROTATE_180 = 28, // image is rotated by 180?
            CAMERA_FEATURES_CAMMODE_NG = 29, // camera has a next-generation register mapping
            CAMERA_FEATURES_CAMMODE_CLASSIC = 30, // camera has a classic register mapping
            CAMERA_FEATURES_NEXT_FEATUREVECTOR = 31, // a subsequent feature vector is available
            // Extended feature vector
            CAMERA_FEATURES2_START = 32, // first extended camera feature
            CAMERA_FEATURES2_1_TAP = 32, // camera supports a single tap sensor
            CAMERA_FEATURES2_2_TAP = 33, // camera supports a dual tap sensor
            CAMERA_FEATURES2_3_TAP = 34, // camera supports a triple tap sensor
            CAMERA_FEATURES2_4_TAP = 35, // camera supports a quadruple tap sensor
            CAMERA_FEATURES2_REBOOT = 36, // a remote reboot command is supported
            CAMERA_FEATURES2_IOMUX = 37, // IO multiplexer functionality is available
            CAMERA_FEATURES2_SOFTWARE_TRIGGER_ID = 38, // writing a software trigger ID into images is supported
            CAMERA_FEATURES2_39 = 39, // reserved
            CAMERA_FEATURES2_40 = 40, // reserved
            CAMERA_FEATURES2_41 = 41, // reserved
            CAMERA_FEATURES2_42 = 42, // reserved
            CAMERA_FEATURES2_IOMUX_PWM = 43, // PWM A and B signals are available in IO multiplexer
            CAMERA_FEATURES2_IOMUX_STROBE2 = 44, // STROBE0 and STROBE1 signals are available in IO multiplexer
            CAMERA_FEATURES2_45 = 45, // reserved
            CAMERA_FEATURES2_IOMUX_EXPOSE = 46, // EXPOSE signal is available in IO multiplexer
            CAMERA_FEATURES2_IOMUX_READOUT = 47, // READOUT signal is available in IO multiplexer
        }

        /** Look-up table mode.     // Ver. 1.4.16.40
           *  A camera can be instructed to apply a look-up table. Usually this will
           *  be used for running a gamma correction. However, other goals can also
           *  be implemented by a look-up table, like converting a gray-scale picture 
           *  into a binary black/white picture.
        */
        public enum LUT_MODE : int
        {
            LUT_MODE_DISABLED = 0,
            LUT_MODE_WHITE_BALANCE = 1,    // 2006-12-20: deactivated, use  
            // Camera_setWhiteBalance() instead
            LUT_MODE_ENABLED = 2,

        }

        /** Binning mode.         // Ver. 1.4.16.40
           *  A camera can be set to one of the following pre-defined binning modes
        */
        public enum BINNING_MODE : int
        {
            BINNING_MODE_OFF = 0,
            BINNING_MODE_HORIZONTAL,
            BINNING_MODE_VERTICAL,
            BINNING_MODE_2x2,
            BINNING_MODE_3x3,
            BINNING_MODE_4x4,
        }

        /** Lowpass filter.
         *  A lowpass filter can be activated/deactivated according to the
         *  following options.
         */
        public enum LOWPASS_FILTER : int
        {
            LOWPASS_FILTER_NONE = 0,
            LOWPASS_FILTER_3X3 = 1,

        }


        /** Multicast mode      // Ver. 1.4.16.40
           *  An application can receive images from a camera as a multicast controller,
           *  multicast listener or by non-multicast (default, unicast).
        */
        public enum MULTICAST_MODE : int
        {
            MULTICAST_MODE_NONE = 0,
            MULTICAST_MODE_LISTENER = 1,
            MULTICAST_MODE_CONTROLLER = 2

        }

        /** Acquisition Mode */
        // Ver. 1.4.16.40
        public enum ACQUISITION_MODE : int
        {
            //ACQUISITION_MODE_NO_ACQUISITION = 0, // deprecated
            ACQUISITION_MODE_FIXED_FREQUENCY = 1,
            ACQUISITION_MODE_SOFTWARE_TRIGGER = 2,
            ACQUISITION_MODE_EXT_TRIGGER_INT_EXPOSURE = 3,
            ACQUISITION_MODE_EXT_TRIGGER_EXT_EXPOSURE = 4,

        }

        /** Acquisition control        // Ver. 1.4.16.40
         *  A camera can be set to the following acquisition control modes
        */
        public enum ACQUISITION_CONTROL : uint
        {
            ACQUISITION_CONTROL_STOP = 0,
            ACQUISITION_CONTROL_START = 1,

        }

        /** Trigger polarity.       // Ver. 1.4.16.40
         *  A camera can be set to positive or negative trigger polarity
        */
        public enum TRIGGER_POLARITY : uint
        {
            TRIGGER_POLARITY_POSITIVE = 0,
            TRIGGER_POLARITY_NEGATIVE = 1,

        }

        /** Strobe polarity.      // Ver. 1.4.16.40
         *  A camera can be set to positive or negative strobe polarity
         */
        public enum STROBE_POLARITY : uint
        {
            STROBE_POLARITY_POSITIVE = 0,
            STROBE_POLARITY_NEGATIVE = 1,

        }

        /** Pive mode // Ver. 1.4.23.56
         *  A  camera can be set to enabled or disabled Piv mode 
        */
        public enum PIV_MODE : uint
        {
            PIV_MODE_ENABLED = 1,
            PIV_MODE_DISABLED = 0,
        }

        /** Tap selection defines.
            *  Each tap of a 2-tap or 4-tap camera can be selected
            *  by using one of the following defines.
           */

        public enum SVGIGE_TAP_SELECT : uint
        {
            SVGIGE_TAP_SELECT_TAP0 = 0,
            SVGIGE_TAP_SELECT_TAP1 = 1,
            SVGIGE_TAP_SELECT_TAP2 = 2,
            SVGIGE_TAP_SELECT_TAP3 = 3,
        }


        /** Bayer conversion method   */
        // Ver. 1.4.16.40       
        public enum BAYER_METHOD : int
        {
            BAYER_METHOD_NONE = -1,
            BAYER_METHOD_NEAREST = 0,  // 2009-03-30: deprecated, mapped to BAYER_METHOD_SIMPLE
            BAYER_METHOD_SIMPLE = 1,
            BAYER_METHOD_BILINEAR = 2,  // 2009-03-30: deprecated, mapped to BAYER_METHOD_HQLINEAR
            BAYER_METHOD_HQLINEAR = 3,
            BAYER_METHOD_EDGESENSE = 4,  // 2009-03-30: deprecated, mapped to BAYER_METHOD_HQLINEAR
            BAYER_METHOD_GRAY = 5,
        };


        /** Pixel depth defines.
         *  The following pixel depths can be supported by a camera
         */
        public enum SVGIGE_PIXEL_DEPTH : uint   // Ver. 1.4.16.40       
        {
            SVGIGE_PIXEL_DEPTH_8 = 0,
            //SVGIGE_PIXEL_DEPTH_10    =1, // not supported 
            SVGIGE_PIXEL_DEPTH_12 = 2,
            SVGIGE_PIXEL_DEPTH_16 = 3,
        };

        /** Correction step.
         *  While performing image correction, a sequence of
         *  particular steps is needed as they are defined below .
         */
        public enum IMAGE_CORRECTION_STEP : uint   // Ver. 1.4.24.59       
        {
            IMAGE_CORRECTION_IDLE = 0,
            IMAGE_CORRECTION_ACQUIRE_BLACK_IMAGE = 1,
            IMAGE_CORRECTION_ACQUIRE_WHITE_IMAGE = 2,
            IMAGE_CORRECTION_SAVE_TO_EEPROM = 3,

        };

        /** Correction mode.
         *  After a successful image correction run, one of
         *  the following modes can be activated in order to
         *  control what image correction method is used.
         */
        public enum IMAGE_CORRECTION_MODE : uint   // Ver. 1.4.24.59       
        {
            IMAGE_CORRECTION_NONE = 0,
            IMAGE_CORRECTION_OFFSET_ONLY = 1,
            IMAGE_CORRECTION_ENABLED = 2,

        };


        /** Auto tap balance modes.
          *  The following modes of auto tap balancing are available
          */
        public enum SVGIGE_AUTO_TAP_BALANCE_MODE : uint  // Ver. 1.4.16.40
        {
            SVGIGE_AUTO_TAP_BALANCE_MODE_OFF = 0,
            SVGIGE_AUTO_TAP_BALANCE_MODE_ONCE = 1,
            SVGIGE_AUTO_TAP_BALANCE_MODE_CONTINUOUS = 2,

        }


        public enum GVSP_PIXEL_TYPE : uint   // Ver. 1.4.16.40
        {
            // Unknown pixel format
            GVSP_PIX_UNKNOWN = 0x0000,

            // Mono buffer format defines
            GVSP_PIX_MONO8 = (GVSP_PIX_MONO | GVSP_PIX_OCCUPY8BIT | 0x0001),
            GVSP_PIX_MONO10 = (GVSP_PIX_MONO | GVSP_PIX_OCCUPY16BIT | 0x0003),
            GVSP_PIX_MONO10_PACKED = (GVSP_PIX_MONO | GVSP_PIX_OCCUPY12BIT | 0x0004),
            GVSP_PIX_MONO12 = (GVSP_PIX_MONO | GVSP_PIX_OCCUPY16BIT | 0x0005),
            GVSP_PIX_MONO12_PACKED = (GVSP_PIX_MONO | GVSP_PIX_OCCUPY12BIT | 0x0006),
            GVSP_PIX_MONO16 = (GVSP_PIX_MONO | GVSP_PIX_OCCUPY16BIT | 0x0007),

            // Bayer buffer format defines
            GVSP_PIX_BAYGR8 = (GVSP_PIX_MONO | GVSP_PIX_OCCUPY8BIT | 0x0008),
            GVSP_PIX_BAYRG8 = (GVSP_PIX_MONO | GVSP_PIX_OCCUPY8BIT | 0x0009),
            GVSP_PIX_BAYGB8 = (GVSP_PIX_MONO | GVSP_PIX_OCCUPY8BIT | 0x000A),
            GVSP_PIX_BAYBG8 = (GVSP_PIX_MONO | GVSP_PIX_OCCUPY8BIT | 0x000B),
            GVSP_PIX_BAYGR10 = (GVSP_PIX_MONO | GVSP_PIX_OCCUPY16BIT | 0x000C),
            GVSP_PIX_BAYRG10 = (GVSP_PIX_MONO | GVSP_PIX_OCCUPY16BIT | 0x000D),
            GVSP_PIX_BAYGB10 = (GVSP_PIX_MONO | GVSP_PIX_OCCUPY16BIT | 0x000E),
            GVSP_PIX_BAYBG10 = (GVSP_PIX_MONO | GVSP_PIX_OCCUPY16BIT | 0x000F),
            GVSP_PIX_BAYGR12 = (GVSP_PIX_MONO | GVSP_PIX_OCCUPY16BIT | 0x0010),
            GVSP_PIX_BAYRG12 = (GVSP_PIX_MONO | GVSP_PIX_OCCUPY16BIT | 0x0011),
            GVSP_PIX_BAYGB12 = (GVSP_PIX_MONO | GVSP_PIX_OCCUPY16BIT | 0x0012),
            GVSP_PIX_BAYBG12 = (GVSP_PIX_MONO | GVSP_PIX_OCCUPY16BIT | 0x0013),

            // Color buffer format defines
            GVSP_PIX_RGB24 = (GVSP_PIX_RGB | GVSP_PIX_OCCUPY24BIT),

            // Define for a gray image that was converted from a bayer coded image
            GVSP_PIX_GRAY8 = (GVSP_PIX_MONO | GVSP_PIX_OCCUPY8BIT),
        }

        //-----------------------------------------------------------------------------------
        //-----------------------------------------------------------------------------------


        /** Signal types             // Ver. 1.4.16.40
         *  Each image that is delivered to an application by a callback will have a related signal
         *  which informs about the circumstances why a callback was triggered.
         *
         *  Usually a complete image will be delivered with the SVGigE_SIGNAL_FRAME_COMPLETED signal.
         */
        public enum SVGigE_SIGNAL_TYPE : uint
        {
            SVGigE_SIGNAL_NONE = 0,
            SVGigE_SIGNAL_FRAME_COMPLETED = 1,   // new image available, transfer was successful
            SVGigE_SIGNAL_FRAME_ABANDONED = 2,   // an image could not be completed in time and was therefore abandoned
            SVGigE_SIGNAL_START_OF_TRANSFER = 3,   // transfer of a new image has started
            SVGigE_SIGNAL_BANDWIDTH_EXCEEDED = 4,   // available network bandwidth has been exceeded
            SVGigE_SIGNAL_OLD_STYLE_DATA_PACKETS = 5,   // driver problem due to old-style driver behavior (prior to 2003, not WDM driver)
            SVGigE_SIGNAL_TEST_PACKET = 6,   // a test packet arrived
            SVGigE_SIGNAL_CAMERA_MESSAGE = 7,   // a camera message arrived (not implemented yet)
            SVGigE_SIGNAL_CAMERA_CONNECTION_LOST = 8,   // connection to camera got lost
            SVGigE_SIGNAL_CAMERA_FOUND = 9,   // a new camera device was discovered in the network (Linux only)
            SVGigE_SIGNAL_MULTICAST_MESSAGE = 10,  // an exceptional situation occurred during a multicast transmission
            SVGigE_SIGNAL_MESSAGE_FIFO_OVERRUN = 11,  // a next entry was put into the message FIFO before the old one was released

        }

        //------------------------------------------------------------------------------
        //------------------------------------------------------------------------------

        /* ***********************************************************************************

        IOMUX

        *********************************************************************************** */

        // f黵 IV kompatibilit鋞
        public const uint GVCP_USER_SPACE_UART_TX = 0xA700;
        public const uint GVCP_USER_SPACE_UART_RX = 0xA704;
        public const uint GVCP_USER_SPACE_SPARE = 0xA708;


        public const uint GVCP_USER_SPACE_IOMUX = 0xA700;
        public const uint GVCP_USER_SPACE_IOMUX_END = 0xA800;

        public const uint GVCP_USER_SPACE_IOMUX_SPARE = 0xA708;
        public const uint GVCP_USER_SPACE_IOMUX_BAUDRATE = 0xA70C;
        public const uint GVCP_USER_SPACE_IOMUX_IO_IN = 0xA710;
        public const uint GVCP_USER_SPACE_IOMUX_IO_OUT = 0xA714;
        public const uint GVCP_USER_SPACE_IOMUX_OVR_OUT = 0xA718;
        public const uint GVCP_USER_SPACE_IOMUX_IO_OUT0_MASK = 0xA71C;
        public const uint GVCP_USER_SPACE_IOMUX_IO_OUT1_MASK = 0xA720;
        public const uint GVCP_USER_SPACE_IOMUX_IO_OUT2_MASK = 0xA724;
        public const uint GVCP_USER_SPACE_IOMUX_IO_OUT3_MASK = 0xA728;
        public const uint GVCP_USER_SPACE_IOMUX_IO_OUT4_MASK = 0xA72C;
        public const uint GVCP_USER_SPACE_IOMUX_IO_OUT5_MASK = 0xA730;
        public const uint GVCP_USER_SPACE_IOMUX_IO_OUT6_MASK = 0xA734;
        public const uint GVCP_USER_SPACE_IOMUX_IO_OUT7_MASK = 0xA738;
        public const uint GVCP_USER_SPACE_IOMUX_IO_OUT8_MASK = 0xA73C;
        public const uint GVCP_USER_SPACE_IOMUX_IO_OUT9_MASK = 0xA740;
        public const uint GVCP_USER_SPACE_IOMUX_IO_OUT10_MASK = 0xA744;
        public const uint GVCP_USER_SPACE_IOMUX_IO_OUT11_MASK = 0xA748;
        public const uint GVCP_USER_SPACE_IOMUX_IO_OUT12_MASK = 0xA74C;
        public const uint GVCP_USER_SPACE_IOMUX_IO_OUT13_MASK = 0xA750;
        public const uint GVCP_USER_SPACE_IOMUX_IO_OUT14_MASK = 0xA754;
        public const uint GVCP_USER_SPACE_IOMUX_IO_OUT15_MASK = 0xA758;
        public const uint GVCP_USER_SPACE_IOMUX_IO_OUT16_MASK = 0xA75C;
        public const uint GVCP_USER_SPACE_IOMUX_IO_OUT17_MASK = 0xA760;
        public const uint GVCP_USER_SPACE_IOMUX_IO_OUT18_MASK = 0xA764;
        public const uint GVCP_USER_SPACE_IOMUX_IO_OUT19_MASK = 0xA768;
        public const uint GVCP_USER_SPACE_IOMUX_IO_OUT20_MASK = 0xA76C;
        public const uint GVCP_USER_SPACE_IOMUX_IO_OUT21_MASK = 0xA770;
        public const uint GVCP_USER_SPACE_IOMUX_IO_OUT22_MASK = 0xA774;
        public const uint GVCP_USER_SPACE_IOMUX_IO_OUT23_MASK = 0xA778;
        public const uint GVCP_USER_SPACE_IOMUX_IO_OUT24_MASK = 0xA77C;
        public const uint GVCP_USER_SPACE_IOMUX_IO_OUT25_MASK = 0xA780;
        public const uint GVCP_USER_SPACE_IOMUX_IO_OUT26_MASK = 0xA784;
        public const uint GVCP_USER_SPACE_IOMUX_IO_OUT27_MASK = 0xA788;
        public const uint GVCP_USER_SPACE_IOMUX_IO_OUT28_MASK = 0xA78C;
        public const uint GVCP_USER_SPACE_IOMUX_IO_OUT29_MASK = 0xA790;
        public const uint GVCP_USER_SPACE_IOMUX_IO_OUT30_MASK = 0xA794;
        public const uint GVCP_USER_SPACE_IOMUX_IO_OUT31_MASK = 0xA798;
        public const uint GVCP_USER_SPACE_IOMUX_IO_IN_COUNT = 0xA79C;
        public const uint GVCP_USER_SPACE_IOMUX_IO_OUT_COUNT = 0xA7A0;
        //...
        public const uint GVCP_USER_SPACE_IOMUX_ACQ_LED_OVR = 0xA7F4;
        public const uint GVCP_USER_SPACE_IOMUX_DEBUG = 0xA7F8;
        public const uint GVCP_USER_SPACE_IOMUX_LED_INTENSITY = 0xA7FC;

        public const uint GVCP_USER_SPACE_IOMUX_UART_IN = GVCP_USER_SPACE_IOMUX_IO_OUT5_MASK;
        public const uint GVCP_USER_SPACE_IOMUX_IO_TXD_MASK = GVCP_USER_SPACE_IOMUX_IO_OUT4_MASK;
        public const uint GVCP_USER_SPACE_IOMUX_TRIGGER = GVCP_USER_SPACE_IOMUX_IO_OUT6_MASK;

        public const uint IOMUX_IN_MASK_STROBE = (1 << 6);
        public const uint IOMUX_IN_MASK_UART_OUT = (1 << 5);
        public const uint IOMUX_IN_MASK_IO_RXD = (1 << 4);


        public const uint GVCP_USER_SPACE_IOMUX_RX = 0xBCF8;
        public const uint GVCP_USER_SPACE_IOMUX_TX = 0xBDFC;

        /** IO multiplexer IN signals (signal sources).
         *  A camera provides for a flexible IO signal handling where one or
         *  multiple IN signals (signal sources) can be assigned to an OUT
         *  signal (signal sink). The following IN signals are defined.
         */
        public enum SVGigE_IOMux_IN : int
        {
            SVGigE_IOMUX_IN0 = (1 << 0),
            SVGigE_IOMUX_IN1 = (1 << 1),
            SVGigE_IOMUX_IN2 = (1 << 2),
            SVGigE_IOMUX_IN3 = (1 << 3),
            SVGigE_IOMUX_IN4 = (1 << 4),
            SVGigE_IOMUX_IN5 = (1 << 5),
            SVGigE_IOMUX_IN6 = (1 << 6),
            SVGigE_IOMUX_IN7 = (1 << 7),
            SVGigE_IOMUX_IN8 = (1 << 8),
            SVGigE_IOMUX_IN9 = (1 << 9),
            SVGigE_IOMUX_IN10 = (1 << 10),
            SVGigE_IOMUX_IN11 = (1 << 11),
            SVGigE_IOMUX_IN12 = (1 << 12),
            SVGigE_IOMUX_IN13 = (1 << 13),
            SVGigE_IOMUX_IN14 = (1 << 14),
            SVGigE_IOMUX_IN15 = (1 << 15),
            SVGigE_IOMUX_IN16 = (1 << 16),
            SVGigE_IOMUX_IN17 = (1 << 17),
            SVGigE_IOMUX_IN18 = (1 << 18),
            SVGigE_IOMUX_IN19 = (1 << 19),
            SVGigE_IOMUX_IN20 = (1 << 20),
            SVGigE_IOMUX_IN21 = (1 << 21),
            SVGigE_IOMUX_IN22 = (1 << 22),
            SVGigE_IOMUX_IN23 = (1 << 23),
            SVGigE_IOMUX_IN24 = (1 << 24),
            SVGigE_IOMUX_IN25 = (1 << 25),
            SVGigE_IOMUX_IN26 = (1 << 26),
            SVGigE_IOMUX_IN27 = (1 << 27),
            SVGigE_IOMUX_IN28 = (1 << 28),
            SVGigE_IOMUX_IN29 = (1 << 29),
            SVGigE_IOMUX_IN30 = (1 << 30),
            SVGigE_IOMUX_IN31 = (1 << 31)
        }


        /** Some of the multiplexer's IN signals (signal sources) have a
         *  pre-defined usage:
         */
        // READOUT signal from camera
        public const SVGigE_IOMux_IN SVGigE_IOMux_IN_READOUT = SVGigE_IOMux_IN.SVGigE_IOMUX_IN11;

        // EXPOSE signal from camera
        public const SVGigE_IOMux_IN SVGigE_IOMux_IN_EXPOSE = SVGigE_IOMux_IN.SVGigE_IOMUX_IN10;

        // PWMB signal (pulse width modulator)
        public const SVGigE_IOMux_IN SVGigE_IOMux_IN_PWMB = SVGigE_IOMux_IN.SVGigE_IOMUX_IN9;

        // PWMA signal (pulse width modulator)
        public const SVGigE_IOMux_IN SVGigE_IOMux_IN_PWMA = SVGigE_IOMux_IN.SVGigE_IOMUX_IN8;

        // STROBE1 and STROBE2 signal from the camera
        public const SVGigE_IOMux_IN SVGigE_IOMux_IN_STROBE_0and1 = (SVGigE_IOMux_IN)((int)SVGigE_IOMux_IN.SVGigE_IOMUX_IN6 | (int)SVGigE_IOMux_IN.SVGigE_IOMUX_IN7);

        // STROBE1 signal from the camera
        public const SVGigE_IOMux_IN SVGigE_IOMux_IN_STROBE1 = SVGigE_IOMux_IN.SVGigE_IOMUX_IN7;

        // STROBE0 signal from the camera (same as STROBE)
        public const SVGigE_IOMux_IN SVGigE_IOMux_IN_STROBE0 = SVGigE_IOMux_IN.SVGigE_IOMUX_IN6;

        // Strobe signal from the camera
        public const SVGigE_IOMux_IN SVGigE_IOMux_IN_STROBE = SVGigE_IOMux_IN.SVGigE_IOMUX_IN6;

        // Transmitter output from UART
        public const SVGigE_IOMux_IN SVGigE_IOMux_IN_UART_OUT = SVGigE_IOMux_IN.SVGigE_IOMUX_IN5;

        // Receiver IO line from camera connector
        public const SVGigE_IOMux_IN SVGigE_IOMux_IN_IO_RXD = SVGigE_IOMux_IN.SVGigE_IOMUX_IN4;

        // Fixed High signal (2010-09-16/EKantz: changed from 8 to 31)
        public const SVGigE_IOMux_IN SVGigE_IOMux_IN_FIXED_HIGH = SVGigE_IOMux_IN.SVGigE_IOMUX_IN31;
        // Fixed Low signal (2010-09-16/EKantz: changed from 7 to 30)
        public const SVGigE_IOMux_IN SVGigE_IOMux_IN_FIXED_LOW = SVGigE_IOMux_IN.SVGigE_IOMUX_IN30;

        /** Signal values for a particular signal
         */
        public enum SVGigE_IO_Signal : uint
        {
            IO_SIGNAL_OFF = 0,
            IO_SIGNAL_ON = 1
        }


        /** IO multiplexer OUT signals (signal sinks).
            *  A camera provides for a flexible IO signal handling where one or
            *  multiple IN signals (signal sources) can be assigned to an OUT
            *  signal (signal sink). The following OUT signals are defined.
        */

        public enum SVGigE_IOMux_OUT : int
        {
            SVGigE_IOMUX_OUT0 = 0,
            SVGigE_IOMUX_OUT1 = 1,
            SVGigE_IOMUX_OUT2 = 2,
            SVGigE_IOMUX_OUT3 = 3,
            SVGigE_IOMUX_OUT4 = 4,
            SVGigE_IOMUX_OUT5 = 5,
            SVGigE_IOMUX_OUT6 = 6,
            SVGigE_IOMUX_OUT7 = 7,
            SVGigE_IOMUX_OUT8 = 8,
            SVGigE_IOMUX_OUT9 = 9,
            SVGigE_IOMUX_OUT10 = 10,
            SVGigE_IOMUX_OUT11 = 11,
            SVGigE_IOMUX_OUT12 = 12,
            SVGigE_IOMUX_OUT13 = 13,
            SVGigE_IOMUX_OUT14 = 14,
            SVGigE_IOMUX_OUT15 = 15,
            SVGigE_IOMUX_OUT16 = 16,
            SVGigE_IOMUX_OUT17 = 17,
            SVGigE_IOMUX_OUT18 = 18,
            SVGigE_IOMUX_OUT19 = 19,
            SVGigE_IOMUX_OUT20 = 20,
            SVGigE_IOMUX_OUT21 = 21,
            SVGigE_IOMUX_OUT22 = 22,
            SVGigE_IOMUX_OUT23 = 23,
            SVGigE_IOMUX_OUT24 = 24,
            SVGigE_IOMUX_OUT25 = 25,
            SVGigE_IOMUX_OUT26 = 26,
            SVGigE_IOMUX_OUT27 = 27,
            SVGigE_IOMUX_OUT28 = 28,
            SVGigE_IOMUX_OUT29 = 29,
            SVGigE_IOMUX_OUT30 = 30,
            SVGigE_IOMUX_OUT31 = 31,
        }


        /** Some of the multiplexer's OUT signals (signal sinks) have a
         *  pre-defined usage:
         */
        // Trigger signal to camera
        public const uint SVGigE_IOMux_OUT_TRIGGER = (int)(SVGigE_IOMux_OUT.SVGigE_IOMUX_OUT6);

        // Receiver input to UART
        public const uint SVGigE_IOMux_OUT_UART_IN = (int)(SVGigE_IOMux_OUT.SVGigE_IOMUX_OUT5);

        // Transmitter IO line from camera connector
        public const uint SVGigE_IOMux_OUT_IO_TXD = (int)(SVGigE_IOMux_OUT.SVGigE_IOMUX_OUT4);


        //------------------------------------------------------------------------------
        //------------------------------------------------------------------------------


        /** Baud rate for a camera's UART
         *  A camera's UART can be set to the following pre-defined baud rates.
         */
        public enum SVGigE_BaudRate : uint
        {
            SVGigE_BaudRate_110 = 110,
            SVGigE_BaudRate_300 = 300,
            SVGigE_BaudRate_1200 = 1200,
            SVGigE_BaudRate_2400 = 2400,
            SVGigE_BaudRate_4800 = 4800,
            SVGigE_BaudRate_9600 = 9600,
            SVGigE_BaudRate_19200 = 19200,
            SVGigE_BaudRate_38400 = 38400,
            SVGigE_BaudRate_57600 = 57600,
            SVGigE_BaudRate_115200 = 115200,
        }


        public static int callbackCount = 0;
        private int hCamera;

        public GigeApi()
        {
            //
            // TODO: F黦en Sie hier die Konstruktorlogik hinzu
            //
        }



        //------------------------------------------------------------------------------
        // 0 - GigE DLL and driver
        //------------------------------------------------------------------------------

        /** isVersionCompliant.
        *  The DLL's version at compile time will be checked against an expected
        *  version at runtime. The calling program knows the runtime version that
        *  it needs for proper functioning and can handle a version mismatch, e.g.
        *  by displaying the expected and the found DLL version to the user.
        *
          *  NOTE: If the DLL version matches expected version, then subsequently a
          *        check for driver availability will be performed. The result may be:
          *          - "not installed" (if no SVGigE driver could be found)
          *          - "not available" (if a driver is installed but communication failed, e.g. x86 on x64)
        *
        *  @param DllVersion a pointer to a version structure for the current DLL version
        *  @param ExpectedVersion a pointer to a version structure with the expected DLL version
        *  @return SVGigE_SUCCESS or an appropriate SVGigE error code
        */
        /* TODO: Find out how to declare struct in C# compliant to C++
       [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)] private static extern unsafe 
                 SVSGigeApiReturn
       isVersionCompliantDLL(SVGigE_VERSION *DllVersion,
                             SVGigE_VERSION *ExpectedVersion);
     */

        /** isDriverAvailable.
         *  It will be checked whether a FilterDriver is available. The following return codes apply:
           *    - "success" - driver is installed and available for work
           *    - "TL not loaded" - a FilterDriver transport layer is not available
           *    - "not installed" - no FilterDriver installed
           *    - "not available" - FilterDriver installed but not available (e.g. x86 on x64)
         *
         *  @return SVGigE_SUCCESS or an appropriate SVGigE return code
         */
        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
            SVSGigeApiReturn
            isDriverAvailable();

        //------------------------------------------------------------------------------
        // 1 - Camera: Discovery and bookkeeping
        //------------------------------------------------------------------------------	

        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
        int
        CameraContainer_create(SVGigETL_Type TransPortLayerType);

        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
        void
        CameraContainer_delete(int hCameraContainer);

        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
            SVSGigeApiReturn
            CameraContainer_discovery(int hCameraContainer);

        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
            int
            CameraContainer_getNumberOfCameras(int hCameraContainer);

        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
            int
            CameraContainer_getCamera(int hCameraContainer,
            int CameraIndex);

        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
            void* CameraContainer_findCamera(int hCameraContainer,
            sbyte* CameraItem);
        //------------------------------------------------------------------------------
        // 2 - Camera: Connection
        //------------------------------------------------------------------------------	

        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
            SVSGigeApiReturn
            Camera_openConnection(int hCamera, float Timeout);

        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
            SVSGigeApiReturn
            Camera_closeConnection(int hCamera);

        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
            SVSGigeApiReturn
            Camera_setIPAddress(int hCamera, uint IPAddress, uint NetMask);

        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
            SVSGigeApiReturn
            Camera_forceValidNetworkSettings(int hCamera, uint* IPAddress, uint* SubnetMask);


        //------------------------------------------------------------------------------
        // 3 - Camera: Information
        //------------------------------------------------------------------------------

        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
            sbyte*
            Camera_getManufacturerName(int hCamera);

        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
            sbyte*
            Camera_getModelName(int hCamera);

        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
            sbyte*
            Camera_getDeviceVersion(int hCamera);

        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
            sbyte*
            Camera_getManufacturerSpecificInformation(int hCamera);

        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
            sbyte*
            Camera_getSerialNumber(int hCamera);

        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
            SVSGigeApiReturn
            Camera_setUserDefinedName(int hCamera, sbyte* UserDefinedName);

        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
            sbyte*
            Camera_getUserDefinedName(int hCamera);

        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
            sbyte*
            Camera_getMacAddress(int hCamera);

        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
            sbyte*
            Camera_getIPAddress(int hCamera);


        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
            sbyte*
            Camera_getSubnetMask(int hCamera);


        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
            SVSGigeApiReturn
            Camera_getPixelClock(int hCamera,
            int* PixelClock);

        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe bool
            Camera_isCameraFeature(int hCamera, CAMERA_FEATURE Feature);

        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
            SVSGigeApiReturn
            Camera_readXMLFile(int hCamera, char** XML);



        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
            SVSGigeApiReturn
            Camera_getSensorTemperature(int hCamera,
            uint* SensorTemperature);



        //------------------------------------------------------------------------------
        // 4 - Stream: Channel creation and control
        //------------------------------------------------------------------------------

        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
            SVSGigeApiReturn
            StreamingChannel_create(int* hStreamingChannel,
            int hCameraContainer,
            int hCamera,
            int BufferCount,
            StreamCallback CallbackFunction,
            void* Context);



        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
            SVSGigeApiReturn
            StreamingChannel_delete(int hStreamingChannel);


        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
            SVSGigeApiReturn
            StreamingChannel_setChannelTimeout(int hStreamingChannel,
            float ChannelTimeout);

        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
            SVSGigeApiReturn
            StreamingChannel_getChannelTimeout(int hStreamingChannel,
            float* ProgrammedChannelTimeout);

        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
            SVSGigeApiReturn
            StreamingChannel_setReadoutTransfer(int hStreamingChannel,
            bool isReadoutTransfer);

        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
        SVSGigeApiReturn
        StreamingChannel_getReadoutTransfer(int hStreamingChannel,
                                          bool* isReadoutTransfer);


        //------------------------------------------------------------------------------
        // 5 - Stream: Channel statistics
        //------------------------------------------------------------------------------

        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
        SVSGigeApiReturn
        StreamingChannel_getFrameLoss(int hStreamingChannel,
                                    int* FrameLoss);

        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
        SVSGigeApiReturn
        StreamingChannel_getActualFrameRate(int hStreamingChannel,
                                          float* ActualFrameRate);

        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
        SVSGigeApiReturn
        StreamingChannel_getActualDataRate(int hStreamingChannel,
                                         float* ActualDataRate);
        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
        SVSGigeApiReturn
        StreamingChannel_getPeakDataRate(int hStreamingChannel,
                                         float* PeakDataRate);

        //------------------------------------------------------------------------------
        // 6 - Stream: Channel info 
        //------------------------------------------------------------------------------


        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
        SVSGigeApiReturn
        StreamingChannel_getPixelType(int hStreamingChannel,
                                      GVSP_PIXEL_TYPE* ProgrammedPixelType);


        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
        SVSGigeApiReturn
        StreamingChannel_getBufferData(int hStreamingChannel,
                                      uint BufferIndex,
                                      sbyte** BufferData);


        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
        SVSGigeApiReturn
        StreamingChannel_getBufferSize(int hStreamingChannel,
                                       int* BufferSize);


        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
        SVSGigeApiReturn
        StreamingChannel_getImagePitch(int hStreamingChannel,
                                       int* ImagePitch);



        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
        SVSGigeApiReturn
        StreamingChannel_getImageSizeX(int hStreamingChannel,
                                       int* ImageSizeX);

        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
        SVSGigeApiReturn
        StreamingChannel_getImageSizeY(int hStreamingChannel,
                                       int* ImageSizeY);

        //------------------------------------------------------------------------------
        // 7 - Stream: Transfer Parameters
        //------------------------------------------------------------------------------

        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
        SVSGigeApiReturn
        Camera_evaluateMaximalPacketSize(int hCamera,
                                         int* MaximalPacketSize);

        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
        SVSGigeApiReturn
        Camera_setStreamingPacketSize(int hCamera,
                                      int StreamingPacketSize);

        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
        SVSGigeApiReturn
        Camera_setInterPacketDelay(int hCamera,
                                   float InterPacketDelay);


        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
        SVSGigeApiReturn
        Camera_getInterPacketDelay(int hCamera,
                                   float* ProgrammedInterPacketDelay);

        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
        SVSGigeApiReturn
        Camera_setMulticastMode(int hCamera,
                                MULTICAST_MODE MulticastMode);

        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
        SVSGigeApiReturn
        Camera_getMulticastMode(int hCamera,
                                MULTICAST_MODE* MulticastMode);


        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
        SVSGigeApiReturn
        Camera_getMulticastGroup(int hCamera,
                                 uint* MulticastGroup,
                                 uint* MulticastPort);


        //------------------------------------------------------------------------------
        // 8 - Stream: Image access
        //------------------------------------------------------------------------------

        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
            sbyte*
            Image_getDataPointer(int hImage);

        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
            int Image_getBufferIndex(int hImage);

        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
            SVGigE_SIGNAL_TYPE Image_getSignalType(int hImage);

        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
            int Image_getCamera(int hImage);

        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
            SVSGigeApiReturn
            Image_release(int hImage);

        //------------------------------------------------------------------------------
        // 9 - Stream: Image conversion
        //------------------------------------------------------------------------------

        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
        SVSGigeApiReturn Image_getImageRGB(int hImage, byte* BufferRGB, int BufferLength, BAYER_METHOD BayerMethod);

        /** Get image 12-bit as 8-bit
         *  A 12-bit image will be converted into a 8-bit image. The caller needs to
         *  provide for a sufficient buffer for the 8-bit image.
       *
       *  @param Image an image handle that was received from the callback function
       *  @param Buffer8bit a buffer for 8-bit image data
       *  @param BufferLength the length of the image buffer
       *  @return success or error code
         */

        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
            SVSGigeApiReturn
            Image_getImage12bitAs8bit(int hImage,
                                    byte* Buffer8bit,
                                    int BufferLength);

        /** Get image 12-bit as 16-bit
         *  A 12-bit image will be converted into a 16-bit image. The caller needs to
         *  provide for a sufficiently large buffer (2 x width x height bytes) for the
       *  16-bit image.
       *
       *  @param Image an image handle that was received from the callback function
       *  @param Buffer16bit a buffer for 16-bit image data
       *  @param BufferLength the length of the image buffer
       *  @return success or error code
         */

        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
            SVSGigeApiReturn
            Image_getImage12bitAs16bit(int hImage,
                                     byte* Buffer16bit,
                                     int BufferLength);

        /** Get image 16-bit as 8-bit
         *  A 16-bit image will be converted into a 8-bit image. The caller needs to
         *  provide for a sufficient buffer for the 8-bit image.
       *
       *  @param Image an image handle that was received from the callback function
       *  @param Buffer8bit a buffer for 8-bit image data
       *  @param BufferLength the length of the image buffer
       *  @return success or error code
         */

        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
            SVSGigeApiReturn
            Image_getImage16bitAs8bit(int hImage,
                                    byte* Buffer8bit,
                                    int BufferLength);



        //------------------------------------------------------------------------------
        // 10 - Stream: Image characteristics
        //------------------------------------------------------------------------------

        /**
         * Get pixel type
         * The pixel type as indicated by the camera will be returned
         *
         * @param hStreamingChannel a streaming channel handle received from StreamingChannel_create()
         * @param Image an image handle that was received from the callback function
         * @return the pixel type as indicated by the camera
         */
        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
        GVSP_PIXEL_TYPE Image_getPixelType(int hImage);


        /**
         * Get image size.
         * The number of bytes in the image data field will be returned.
         *
         * @param hStreamingChannel a streaming channel handle received from StreamingChannel_create()
         * @param Image an image handle that was received from the callback function
         * @return the number of bytes in the image data field
         */
        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
int
Image_getImageSize(int hImage);

        /**
         * Get image pitch
         * The number of bytes in a row (pitch) will be returned as received from the camera
         *
         * @param hStreamingChannel a streaming channel handle received from StreamingChannel_create()
         * @param Image an image handle that was received from the callback function
         * @return the image's pitch as received from the camera
         */
        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
        int
        Image_getPitch(int hImage);

        /**
         * Get image size X
         * The horizontal pixel number will be returned as received from the camera
         *
         * @param hStreamingChannel a streaming channel handle received from StreamingChannel_create()
         * @param Image an image handle that was received from the callback function
         * @return the image's size X as received from the camera
         */
        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
           int
         Image_getSizeX(int hImage);

        /**
         * Get image size Y
         * The vertical pixel number will be returned as received from the camera
         *
         * @param hStreamingChannel a streaming channel handle received from StreamingChannel_create()
         * @param Image an image handle that was received from the callback function
         * @return the image's size Y as received from the camera
         */
        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
        int
        Image_getSizeY(int hImage);



        //------------------------------------------------------------------------------
        // 11 - Stream: Image statistics
        //------------------------------------------------------------------------------

        /**
         * Get image identifier.
         *
         * An image identifier will be returned as it was assigned by the camera.
         * Usually the camera will assign an increasing sequence of integer numbers
         * to subsequent images which will wrap at some point and jump back to 1.
         * The 0 identifier will not be used as it is defined in the GigE Vision
         * specification
         *
         * @param hStreamingChannel a streaming channel handle received from StreamingChannel_create()
         * @param Image an image handle that was received from the callback function
         * @return an integer number that is unique inside a certain sequence of numbers
         */
        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
            int
            Image_getImageID(int hImage);

        /**
         * Get image timestamp
         * The timestamp that was assigned to an image by the camera on image
         * acquisition will be returned
         *
         * @param hStreamingChannel a streaming channel handle received from StreamingChannel_create()
         * @param Image an image handle that was received from the callback function
         * @return a timestamp as it was received from the camera in seconds after
         *   January, 1st 1970 where the fraction represents parts of a second
         */
        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
            double
            Image_getTimestamp(int hImage);


        /** Get image transfer time
         *  The time that elapsed from image's first network packet arriving on PC side
         *  until image completion will be determined, including possible packet resends.
         *
         *  @param Image an image handle that was received from the callback function
         *  @return image's transfer time as it was explained above
         */
        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
            double Image_getTransferTime(int hImage);

        /** Get packet count
         *  The number of packets that belong to a frame will be returned
         *
         *  @param Image an image handle that was received from the callback function
         *  @return the pixel type as indicated by the camera
         */
        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
            int Image_getPacketCount(int hImage);

        /** Get packet resend
         *  The number of packets that have been resent will be reported
         *
         *  @param Image an image handle that was received from the callback function
         *  @return the pixel type as indicated by the camera
         */
        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
            int Image_getPacketResend(int hImage);


        //------------------------------------------------------------------------------
        // 12 - Stream: Messaging channel
        //------------------------------------------------------------------------------

        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
            SVSGigeApiReturn
            Stream_createEvent(int hStreamingChannel,
            int* EventID,
            int SizeFIFO);

        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
            SVSGigeApiReturn
            Stream_addMessageType(int hStreamingChannel,
            int EventID,
            SVGigE_SIGNAL_TYPE MessageType);

        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
            SVSGigeApiReturn
            Stream_removeMessageType(int hStreamingChannel,
            int EventID,
            SVGigE_SIGNAL_TYPE MessageType);

        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
            SVSGigeApiReturn
            Stream_isMessagePending(int hStreamingChannel,
            int EventID,
            int Timeout_ms);

        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
            SVSGigeApiReturn
            Stream_registerEventCallback(int hStreamingChannel,
            int EventID,
            EventCallback Callback,
            void* Context);

        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
            SVSGigeApiReturn
            Stream_unregisterEventCallback(int hStreamingChannel,
            int EventID,
            EventCallback Callback);

        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
            SVSGigeApiReturn
            Stream_getMessage(int hStreamingChannel,
            int EventID,
            int* MessageID,
            SVGigE_SIGNAL_TYPE* MessageType);

        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
            SVSGigeApiReturn
            Stream_getMessageData(int hStreamingChannel,
            int EventID,
            int MessageID,
            void** MessageData,
            int* MessageLength);

        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
            SVSGigeApiReturn
            Stream_getMessageTimestamp(int hStreamingChannel,
            int EventID,
            int MessageID,
            double* MessageTimestamp);

        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
            SVSGigeApiReturn
            Stream_releaseMessage(int hStreamingChannel,
            int EventID,
            int MessageID);

        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
            SVSGigeApiReturn
            Stream_flushMessages(int hStreamingChannel,
            int EventID);

        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
            SVSGigeApiReturn
            Stream_closeEvent(int hStreamingChannel,
            int EventID);


        //------------------------------------------------------------------------------
        // 13 - Controlling camera : Frame rate
        //------------------------------------------------------------------------------

        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
        SVSGigeApiReturn
        Camera_setFrameRate(int hCamera, float Framerate);

        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
        SVSGigeApiReturn
        Camera_getFrameRate(int hCamera, float* ProgrammedFramerate);


        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
        SVSGigeApiReturn Camera_getFrameRateMin(int hCamera, float* MinFramerate);


        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
        SVSGigeApiReturn Camera_getFrameRateMax(int hCamera, float* MaxFramerate);


        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
        SVSGigeApiReturn
          Camera_getFrameRateRange(int hCamera,
                                   float* MinFramerate,
                                   float* MaxFramerate);

        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
        SVSGigeApiReturn
          Camera_getFrameRateIncrement(int hCamera,
                                       float* FramerateIncrement);



        //------------------------------------------------------------------------------
        // 14 - Controlling camera : Exposure
        //------------------------------------------------------------------------------

        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
        SVSGigeApiReturn
        Camera_setExposureTime(int hCamera, float ExposureTime);

        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
        SVSGigeApiReturn
        Camera_getExposureTime(int hCamera, float* ProgrammedExposureTime);


        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
        SVSGigeApiReturn
          Camera_getExposureTimeMin(int hCamera,
                                    float* MinExposureTime);


        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
        SVSGigeApiReturn
          Camera_getExposureTimeMax(int hCamera,
                                    float* MaxExposureTime);


        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
        SVSGigeApiReturn
          Camera_getExposureTimeRange(int hCamera,
                                      float* MinExposureTime,
                                      float* MaxExposureTime);


        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
        SVSGigeApiReturn
          Camera_getExposureTimeIncrement(int hCamera,
                                    float* ExposureTimeIncrement);

        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
        SVSGigeApiReturn
        Camera_setExposureDelay(int hCamera, float ExposureDelay);

        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
        SVSGigeApiReturn
        Camera_getExposureDelay(int hCamera, float* ProgrammedExposureDelay);


        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
        SVSGigeApiReturn
          Camera_getExposureDelayMax(int hCamera,
                                     float* MaxExposureDelay);

        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
        SVSGigeApiReturn
          Camera_getExposureDelayIncrement(int hCamera,
                                           float* ExposureDelayIncrement);


        //------------------------------------------------------------------------------
        // 15 - Controlling camera : Gain and offset
        //------------------------------------------------------------------------------

        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
        SVSGigeApiReturn
            Camera_setGain(int hCamera,
                float Gain);

        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
        SVSGigeApiReturn
            Camera_getGain(int hCamera,
                float* ProgrammedGain);

        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
        SVSGigeApiReturn
         Camera_getGainMax(int hCamera,
                           float* MaxGain);

        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
        SVSGigeApiReturn
          Camera_getGainMaxExtended(int hCamera,
                                    float* MaxGainExtended);

        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
        SVSGigeApiReturn
          Camera_getGainIncrement(int hCamera,
                                  float* GainIncrement);

        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
        SVSGigeApiReturn
        Camera_setOffset(int hCamera, float Offset);

        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
        SVSGigeApiReturn
        Camera_getOffset(int hCamera, float* ProgrammedOffset);


        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
        SVSGigeApiReturn
          Camera_getOffsetMax(int hCamera,
                              float* MaxOffset);


        //------------------------------------------------------------------------------
        // 16 - Controlling camera: Auto gain / exposure
        //------------------------------------------------------------------------------



        /** Set auto gain enabled
         *  The auto gain status will be switched on or off.
         *
         *  @param Camera a handle from a camera that has been opened before
         *  @param isAutoGainEnabled whether auto gain has to be enabled or disabled
         *  @return SVGigE_SUCCESS or an appropriate SVGigE error code
         */
        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
        SVSGigeApiReturn
        Camera_setAutoGainEnabled(int Camera, bool isAutoGainEnabled);


        /** Get auto gain enabled
         *  Current auto gain status will be returned.
         *
         *  @param Camera a handle from a camera that has been opened before
         *  @param isAutoGainEnabled whether auto gain is enabled or disabled
         *  @return SVGigE_SUCCESS or an appropriate SVGigE error code
         */
        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
        SVSGigeApiReturn
        Camera_getAutoGainEnabled(int Camera, bool* isAutoGainEnabled);

        /** Set auto gain brightness
         *  The target brightness (0..255) will be set which the camera tries to
         *  reach automatically when auto gain/exposure is enabled. The range
         *  0..255 always applies independently from pixel depth.
         *
         *  @param Camera a handle from a camera that has been opened before
         *  @param Brightness the target brightness for auto gain enabled
         *  @return SVGigE_SUCCESS or an appropriate SVGigE error code
         */
        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
        SVSGigeApiReturn
        Camera_setAutoGainBrightness(int Camera, float Brightness);

        /** Get auto gain brightness
         *  The target brightness (0..255) will be returned that the camera tries
         *  to reach automatically when auto gain/exposure is enabled.
         *
         *  @param Camera a handle from a camera that has been opened before
         *  @param ProgrammedBrightness a pointer to a target brightness value
         *  @return SVGigE_SUCCESS or an appropriate SVGigE error code
         */
        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
        SVSGigeApiReturn
        Camera_getAutoGainBrightness(int Camera, float* ProgrammedBrightness);

        /** Set auto gain dynamics
         *  AutoGain PID regulator's time constants for the I (integration) and
         *  D (differentiation) components will be set to new values.
         *
         *  @param Camera a handle from a camera that has been opened before
         *  @param AutoGainParameterI the I parameter in a PID regulation loop
         *  @param AutoGainParameterD the D parameter in a PID regulation loop
         *  @return SVGigE_SUCCESS or an appropriate SVGigE error code
         */
        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
        SVSGigeApiReturn
        Camera_setAutoGainDynamics(int Camera,
                                 float AutoGainParameterI,
                                 float AutoGainParameterD);

        /** Get auto gain dynamics
         *  AutoGain PID regulator's time constants for the I (integration) and
         *  D (differentiation) components will be retrieved from the camera.
         *
         *  @param Camera a handle from a camera that has been opened before
         *  @param ProgrammedAutoGainParameterI the I parameter in a PID regulation loop
         *  @param ProgrammedAutoGainParameterD the D parameter in a PID regulation loop
         *  @return SVGigE_SUCCESS or an appropriate SVGigE error code
         */
        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
        SVSGigeApiReturn
        Camera_getAutoGainDynamics(int Camera,
                                 float* ProgrammedAutoGainParameterI,
                                 float* ProgrammedAutoGainParameterD);

        /** Set auto gain limits
         *  The minimal and maximal gain will be determined that the camera
         *  must not exceed in auto gain/exposure mode.
         *
         *  @param Camera a handle from a camera that has been opened before
         *  @param MinGain the minimal allowed gain value
         *  @param MaxGain the maximal allowed gain value
         *  @return SVGigE_SUCCESS or an appropriate SVGigE error code
         */
        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
        SVSGigeApiReturn
        Camera_setAutoGainLimits(int Camera,
                               float MinGain,
                               float MaxGain);

        /** Get auto gain limits
         *  The minimal and maximal gain will be returned that the camera
         *  must not exceed in auto gain/exposure mode.
         *
         *  @param Camera a handle from a camera that has been opened before
         *  @param ProgrammedMinGain a pointer to the minimal allowed gain value
         *  @param ProgrammedMaxGain a pointer to the maximal allowed gain value
         *  @return SVGigE_SUCCESS or an appropriate SVGigE error code
         */
        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
        SVSGigeApiReturn
        Camera_getAutoGainLimits(int Camera,
                               float* ProgrammedMinGain,
                               float* ProgrammedMaxGain);

        /** Set auto exposure limits
         *  The minimal and maximal exposure will be determined that the camera
         *  must not exceed in auto gain/exposure mode.
         *
         *  @param Camera a handle from a camera that has been opened before
         *  @param MinGain the minimal allowed exposure value
         *  @param MaxGain the maximal allowed exposure value
         *  @return SVGigE_SUCCESS or an appropriate SVGigE error code
         */
        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
        SVSGigeApiReturn
        Camera_setAutoExposureLimits(int Camera,
                                   float MinExposure,
                                   float MaxExposure);

        /** Set auto exposure limits
         *  The minimal and maximal exposure will be determined that the camera
         *  must not exceed in auto gain/exposure mode.
         *
         *  @param Camera a handle from a camera that has been opened before
         *  @param ProgrammedMinExposure the minimal allowed exposure value
         *  @param ProgrammedMaxExposure the maximal allowed exposure value
         *  @return SVGigE_SUCCESS or an appropriate SVGigE error code
         */
        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
        SVSGigeApiReturn
        Camera_getAutoExposureLimits(int Camera,
                                   float* ProgrammedMinExposure,
                                   float* ProgrammedMaxExposure);




        //------------------------------------------------------------------------------
        // 17 - Controlling camera: Acquisition trigger
        //------------------------------------------------------------------------------


        /** Set acquisition control.
         *  The camera's acquisition will be controlled (start/stop).
         *
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param AcquisitionControl the new setting for acquisition control
         *  @return success or error code
         */
        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
        SVSGigeApiReturn
          Camera_setAcquisitionControl(int hCamera, ACQUISITION_CONTROL AcquisitionControl);

        /** Get acquisition control.
         *  The camera's current acquisition control (start/stop) will be returned.
         *
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param AcquisitionControl the currently programmed setting for acquisition control
         *  @return success or error code
         */
        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
        SVSGigeApiReturn
          Camera_getAcquisitionControl(int hCamera, ACQUISITION_CONTROL* AcquisitionControl);

        /**
         * Set acquisition mode.
         * The camera's acquisition mode will be set to the selected value
         *
         * @see CameraContainer_getCamera()
         * @param hCamera a camera handle received from CameraContainer_getCamera()
         * @param AcquisitionMode the new setting for acquisition mode
         * @return success or error code
         */
        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
        SVSGigeApiReturn Camera_setAcquisitionMode(int hCamera, ACQUISITION_MODE AcquisitionMode);

        /** Set Acquisition mode and start
         *  In addition to setting the acquisition mode it can be determined whether
         *  acquisition control will go to enabled or stay on disabled after the new
         *  acquisition mode has been adjusted
         *
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param AcquisitionMode the new setting for acquisition mode
         *  @param AcquisitionStart whether camera control switches to START immediately
         *  @return success or error code
         */
        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
        SVSGigeApiReturn
          Camera_setAcquisitionModeAndStart(int hCamera, ACQUISITION_MODE AcquisitionMode,
                                            bool AcquisitionStart);



        /**
         * Get acquisition mode.
         * The camera's current acquisition mode will be returned
         *
         * @see CameraContainer_getCamera()
         * @param hCamera a camera handle received from CameraContainer_getCamera()
         * @param AcquisitionMode the currently programmed setting for acquisition mode
         * @return success or error code
         */
        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
        SVSGigeApiReturn Camera_getAcquisitionMode(int hCamera, ACQUISITION_MODE* ProgrammedAcquisitionMode);


        /** Software trigger.
         *  The camera will be triggerred for starting a new acquisition cycle.
         *  A mandatory pre-requisition for a successfull software trigger is to have
         *  the camera set to ACQUISITION_MODE_SOFTWARE_TIGGER before.
         *
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @return success or error code
         */
        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
        SVSGigeApiReturn
          Camera_softwareTrigger(int hCamera);

        /** Software trigger ID. (defined but not yet available)
         *  The camera will be triggerred for starting a new acquisition cycle.
         *  A mandatory pre-requisition for a successfull software trigger is to have
         *  the camera set to ACQUISITION_MODE_SOFTWARE_TIGGER before.
         *  In addition to a usual software trigger, an ID will be accepted that
         *  can be written into the image on demand, e.g. for maintaining a unique
         *  trigger/image reference
         *
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param TriggerID an ID to be transferred into first bytes of resulting image data
         *  @return success or error code
         */
        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
        SVSGigeApiReturn
          Camera_softwareTriggerID(int hCamera,
                                   int TriggerID);

        /** Software trigger ID enable. (defined but not yet available)
         *  The "software trigger ID" mode will be enabled respectively disabled
         *
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param TriggerIDEnable whether "trigger ID" will be enabled or disabled
         *  @return success or error code
         */
        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
        SVSGigeApiReturn
          Camera_softwareTriggerIDEnable(int hCamera,
                                         bool TriggerIDEnable);


        /**
         * Set trigger polarity
         * The camera's trigger polarity will be set to the selected value
         *
         * @see CameraContainer_getCamera()
         * @param hCamera a camera handle received from CameraContainer_getCamera()
         * @param TriggerPolarity the new setting for trigger polarity
         * @return success or error code
         */
        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
        SVSGigeApiReturn Camera_setTriggerPolarity(int hCamera, TRIGGER_POLARITY TriggerPolarity);

        /**
         * Get trigger polarity
         * The camera's current trigger polarity will be returned
         *
         * @see CameraContainer_getCamera()
         * @param hCamera a camera handle received from CameraContainer_getCamera()
         * @param TriggerPolarity the currently programmed setting for trigger polarity
         * @return success or error code
         */
        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
         SVSGigeApiReturn Camera_getTriggerPolarity(int hCamera, TRIGGER_POLARITY* ProgrammedTriggerPolarity);

        //.......................Piv Mode ....................

        /** Set a new PIV mode
         *  The camera's PIV mode will be enabled or disabled.
         *
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param PivMode the new setting for PivMode
         *  @return success or error code
        */

        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
         SVSGigeApiReturn Camera_setPivMode(int hCamera, PIV_MODE PivMode);


        /**
         * Get PIV Mode 
         * Check if camera's PIV mode is enabled or disabled.
         *  The state of camera's current Piv mode will be returned
         *
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param ProgrammedPivMode the currently programmed setting for PivMode
         *  @return success or error code
         */
        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
         SVSGigeApiReturn Camera_getPivMode(int hCamera, PIV_MODE* ProgrammedPivMode);



        //.......................Debouncer....................

        /** Set Debouncer  duration
        *   The camera's Debouncer duration will be set to the selected value
        *
        *  @param hCamera a camera handle received from CameraContainer_getCamera()
        *  @param DebouncerDuration the new setting for DebouncerDuration
        *  @return success or error code
         */
        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
        SVSGigeApiReturn Camera_setDebouncerDuration(int hCamera,
                               float DebouncerDuration);

        /** Get Debouncer  duration
         *  The camera's Debouncer  duration will be returned
         *
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param ProgrammedDuration the currently programmed setting for DebouncerDuration.
         *  @return success or error code
         */
        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
         SVSGigeApiReturn Camera_getDebouncerDuration(int hCamera,
                            float* ProgrammedDuration);



        //.......................Prescaler....................

        /** Set prescaler devisor
         *   The camera's prescaler Devisor will be set to the selected value
         *
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param PrescalerDevisor the new setting for PrescalerDevisor
         *  @return success or error code
         */
        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
         SVSGigeApiReturn Camera_setPrescalerDevisor(int hCamera,
                            uint PrescalerDevisor);

        /** Get prescaler devisor
         *  The camera's prescaler devisor will be returned
         *
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param ProgrammedPrescalerDevisor the currently programmed setting for PrescalerDevisor. 
         *  @return success or error code
         */

        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
         SVSGigeApiReturn Camera_getPrescalerDevisor(int hCamera,
                            uint* ProgrammedPrescalerDevisor);


        //.......................Sequencer....................

        /** load Sequence parameters 
         *  New sequence parameters will be loaded from a XML file into the camera  
         *
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param Filename a complete path and filename where to load the settings from
         *  @return success or error code
         */

        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe

         SVSGigeApiReturn Camera_loadSequenceParameters(int hCamera,
                                 string Filename);

        /** Start Sequencer
         * Start aquisition using sequencer.
         * This will occur after loading the appropriate sequence parameters. 
         *
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @return success or error code
         */

        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
        SVSGigeApiReturn Camera_startSequencer(int hCamera);


        //------------------------------------------------------------------------------
        // 18 - Controlling camera: Strobe
        //------------------------------------------------------------------------------
        /**
         * Set strobe polarity
         * The camera's strobe polarity will be set to the selected value
         *
         * @see CameraContainer_getCamera()
         * @param hCamera a camera handle received from CameraContainer_getCamera()
         * @param StrobePolarity the new setting for strobe polarity
         * @return success or error code
         */
        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
        SVSGigeApiReturn
        Camera_setStrobePolarity(int hCamera, STROBE_POLARITY StrobePolarity);

        /** Set strobe polarity extended
         *  The camera's strobe polarity will be set to the selected value
         *
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param StrobePolarity the new setting for strobe polarity
         *  @param StrobIndex the index of the current strobe channel 
         *  @return success or error code
         */

        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
        SVSGigeApiReturn
        Camera_setStrobePolarityExtended(int hCamera, STROBE_POLARITY StrobePolarity, int StrobeIndex);

        /**
         * Get strobe polarity
         * The camera's current strobe polarity will be returned
         *
         * @see CameraContainer_getCamera()
         * @param hCamera a camera handle received from CameraContainer_getCamera()
         * @param StrobePolarity the currently programmed setting for strobe polarity
         * @return success or error code
         */
        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
        SVSGigeApiReturn
        Camera_getStrobePolarity(int hCamera, STROBE_POLARITY* ProgrammedStrobePolarity);

        /** Get strobe polarity extended
         *  The camera's current strobe polarity will be returned
         *
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param StrobePolarity the currently programmed setting for strobe polarity
         *  @param StrobIndex the index of the current strobe channel 
         *  @return success or error code
         */
        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
        SVSGigeApiReturn
        Camera_getStrobePolarityExtended(int hCamera, STROBE_POLARITY* ProgrammedStrobePolarity, int StrobeIndex);

        /**
         * Set strobe position
         * The camera's strobe position in micro seconds relative to the trigger
         * pulse will be set to the selected value
         *
         * @see CameraContainer_getCamera()
         * @param hCamera a camera handle received from CameraContainer_getCamera()
         * @param StrobePosition the new value for strobe position in microseconds
         * @return success or error code
         */
        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
        SVSGigeApiReturn
        Camera_setStrobePosition(int hCamera, float StrobePosition);


        /** Set strobe position extended
         *  The camera's strobe position in micro seconds relative to the trigger
         *  pulse will be set to the selected value
         *
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param StrobePosition the new value for strobe position in microseconds
         *  @param StrobIndex the index of the current strobe channel 
         *  @return success or error code
         */

        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
        SVSGigeApiReturn
        Camera_setStrobePositionExtended(int hCamera, float StrobePosition, int StrobeIndex);

        /**
         * Get strobe position
         * The camera's current strobe position will be returned in micro seconds
         * relative to the trigger pulse
         *
         * @see CameraContainer_getCamera()
         * @param hCamera a camera handle received from CameraContainer_getCamera()
         * @param StrobePosition the currently programmed value for strobe position in microseconds
         * @return success or error code
         */
        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
        SVSGigeApiReturn
        Camera_getStrobePosition(int hCamera, float* ProgrammedStrobePosition);

        /** Get strobe position extended
         *  The camera's current strobe position will be returned in micro seconds
         *  relative to the trigger pulse
         *
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param StrobePosition the currently programmed value for strobe position in microseconds
         *  @param StrobIndex the index of the current strobe channel 
         *  @return success or error code
         */
        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
        SVSGigeApiReturn
        Camera_getStrobePositionExtended(int hCamera, float* ProgrammedStrobePosition, int StrobeIndex);

        /** Get maximal strobe position
         *  The camera's maximal strobe position (delay) will be returned in micro seconds
         *
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param StrobePositionMax the maximal value for strobe position in microseconds
         *  @return success or error code
         */
        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
        SVSGigeApiReturn
          Camera_getStrobePositionMax(int hCamera,
                                   float* MaxStrobePosition);

        /** Get strobe position increment
         *  The camera's strobe position increment will be returned in micro seconds
         *
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param StrobePositionIncrement the strobe position increment in microseconds
         *  @return success or error code
         */
        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
        SVSGigeApiReturn
          Camera_getStrobePositionIncrement(int hCamera,
                                            float* StrobePositionIncrement);

        /**
         * Set strobe duration
         * The camera's strobe duration in micro seconds will be set to the selected
         * value
         *
         * @see CameraContainer_getCamera()
         * @param hCamera a camera handle received from CameraContainer_getCamera()
         * @param StrobeDuration the new value for strobe duration in microseconds
         * @return success or error code
         */
        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
        SVSGigeApiReturn
        Camera_setStrobeDuration(int hCamera, float StrobeDuration);

        /** Set strobe duration extended
         *  The camera's strobe duration in micro seconds will be set to the selected
         *  value
         *
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param StrobeDuration the new value for strobe duration in microseconds
         *  @param StrobIndex the index of the current strobe channel 
         *  @return success or error code
         */
        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
        SVSGigeApiReturn
        Camera_setStrobeDurationExtended(int hCamera, float StrobeDuration, int StrobeIndex);

        /**
         * Get strobe duration
         * The camera's current strobe duration in micro seconds will be returned
         *
         * @see CameraContainer_getCamera()
         * @param hCamera a camera handle received from CameraContainer_getCamera()
         * @param StrobeDuration the currently programmed value for strobe duration in microseconds
         * @return success or error code
         */
        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
        SVSGigeApiReturn
        Camera_getStrobeDuration(int hCamera, float* ProgrammedStrobeDuration);

        /** Get strobe duration extended
         *  The camera's current strobe duration in micro seconds will be returned
         *
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param StrobeDuration the currently programmed value for strobe duration in microseconds
         *  @param StrobIndex the index of the current strobe channel 
         *  @return success or error code
         */
        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
        SVSGigeApiReturn
        Camera_getStrobeDurationExtended(int hCamera, float* ProgrammedStrobeDuration, int StrobeIndex);

        /** Get maximal strobe duration
         *  The camera's maximal strobe duration in micro seconds will be returned
         *
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param MaxStrobeDuration the maximal value for strobe duration in microseconds
         *  @return success or error code
         */
        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
                SVSGigeApiReturn
              Camera_getStrobeDurationMax(int hCamera, float* MaxStrobeDuration);

        /** Get strobe duration increment
         *  The camera's strobe duration increment in micro seconds will be returned
         *
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param StrobeDurationIncrement the strobe duration increment in microseconds
         *  @return success or error code
         */
        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
                SVSGigeApiReturn
              Camera_getStrobeDurationIncrement(int hCamera, float* StrobeDurationIncrement);


        //------------------------------------------------------------------------------
        // 19 - Controlling camera: Tap balance
        //------------------------------------------------------------------------------

        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
        SVSGigeApiReturn
          Camera_saveTapBalanceSettings(int hCamera, sbyte* Filename);

        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
        SVSGigeApiReturn
          Camera_loadTapBalanceSettings(int hCamera, sbyte* Filename);

        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
        SVSGigeApiReturn
          Camera_setTapConfiguration(int hCamera, int TapCount);

        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
        SVSGigeApiReturn
          Camera_getTapConfiguration(int hCamera, int* TapCount);

        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
        SVSGigeApiReturn
          Camera_setAutoTapBalanceMode(int hCamera, SVGIGE_AUTO_TAP_BALANCE_MODE AutoTapBalanceMode);

        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
        SVSGigeApiReturn
          Camera_getAutoTapBalanceMode(int hCamera, SVGIGE_AUTO_TAP_BALANCE_MODE* AutoTapBalanceMode);

        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
        SVSGigeApiReturn
          Camera_setTapGain(int hCamera, float TapGain, SVGIGE_TAP_SELECT TapSelect);

        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
        SVSGigeApiReturn
          Camera_getTapGain(int hCamera, float* TapBalance, SVGIGE_TAP_SELECT TapSelect);



        //------------------------------------------------------------------------------
        // 20 - Controlling camera: Image parameter
        //------------------------------------------------------------------------------

        /** Get imager width.
         *  The imager width will be retrieved from the camera
         *
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param ImagerWidth a reference to the imager width value
         *  @return success or error code
         */
        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
        SVSGigeApiReturn
          Camera_getImagerWidth(int hCamera, int* ImagerWidth);

        /** Get imager height.
         *  The imager height will be retrieved from the camera
         *
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param ImagerHeight a reference to the imager height value
         *  @return success or error code
         */
        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
        SVSGigeApiReturn
          Camera_getImagerHeight(int hCamera, int* ImagerHeight);

        /** Get image size.
         *  The number of bytes in an image will be returned
         *
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param ImageSize a reference to the image size value
         *  @return success or error code
         */
        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
        SVSGigeApiReturn
        Camera_getImageSize(int hCamera, int* ImageSize);

        /** Get pitch.
         *  The number of bytes in a row will be returned
         *
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param Pitch a reference to the pitch value
         *  @return success or error code
         */
        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
        SVSGigeApiReturn
          Camera_getPitch(int hCamera, int* Pitch);

        /** Get size X.
         *  The currently used horizontal picture size X will be retrieved from the camera
         *
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param SizeX a reference to the size X value
         *  @return success or error code
         */
        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
        SVSGigeApiReturn
          Camera_getSizeX(int hCamera, int* SizeX);

        /** Get size Y.
         *  The currently used vertical picture size Y will be retrieved from the camera
         *
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param SizeY a reference to the size Y value
         *  @return success or error code
         */
        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
        SVSGigeApiReturn
          Camera_getSizeY(int hCamera, int* SizeY);



        /**
         * Set binning mode.
         * The camera's binning mode will be set to the selected value
         *
         * @see CameraContainer_getCamera()
         * @param hCamera a camera handle received from CameraContainer_getCamera()
         * @param BinningMode the new setting for binning mode
         * @return success or error code
         */
        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
        SVSGigeApiReturn Camera_setBinningMode(int hCamera, BINNING_MODE BinningMode);

        /**
         * Get binning mode.
         * The camera's current binning mode will be returned
         *
         * @see CameraContainer_getCamera()
         * @param hCamera a camera handle received from CameraContainer_getCamera()
         * @param BinningMode the currently programmed setting for binning mode
         * @return success or error code
         */
        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
        SVSGigeApiReturn Camera_getBinningMode(int hCamera, BINNING_MODE* ProgrammedBinningMode);


        /** Set area of interest (AOI)
         *  The camera will be switched to partial scan mode and an AOI will be set
         *
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param SizeX the number of pixels in one row
         *  @param SizeY the number of scan lines
         *  @param OffsetX a left side offset of the scanned area
         *  @param OffsetY an upper side offset of the scanned area
         *  @return success or error code
         */
        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
        SVSGigeApiReturn
          Camera_setAreaOfInterest(int hCamera,
                                   int SizeX,
                                   int SizeY,
                                   int OffsetX,
                                   int OffsetY);

        /** Get area of interest(AOI)
         *  The currently set parameters for partial scan will be returned
         *
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param ProgrammedSizeX the number of pixels in one row
         *  @param ProgrammedSizeY the number of scan lines
         *  @param ProgrammedOffsetX a left side offset of the scanned area
         *  @param ProgrammedOffsetY an upper side offset of the scanned area
         *  @return success or error code
         */
        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
        SVSGigeApiReturn
          Camera_getAreaOfInterest(int hCamera,
                                   int* ProgrammedSizeX,
                                   int* ProgrammedSizeY,
                                   int* ProgrammedOffsetX,
                                   int* ProgrammedOffsetY);

        /** Get minimal/maximal area of interest(AOI).
         *  The boundaries for partial scan will be returned
         *
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param MinSizeX the minimal AOI width
         *  @param MinSizeY the minimal AOI height
         *  @param MaxSizeX the maximal AOI width
         *  @param MaxSizeY the maximal AOI height
         *  @return success or error code
         */
        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
        SVSGigeApiReturn
          Camera_getAreaOfInterestRange(int hCamera,
                                        int* MinSizeX,
                                        int* MinSizeY,
                                        int* MaxSizeX,
                                        int* MaxSizeY);

        /** Get area of interest(AOI) increment
         *  The increment for partial scan parameters will be returned
         *
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param SizeXIncrement the increment for AOI width
         *  @param SizeYIncrement the increment for AOI height
         *  @param OffsetXIncrement the increment for AOI width offset
         *  @param OffsetYIncrement the increment for AOI height offset
         *  @return success or error code
         */
        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
        SVSGigeApiReturn
          Camera_getAreaOfInterestIncrement(int hCamera,
                                            int* SizeXIncrement,
                                            int* SizeYIncrement,
                                            int* OffsetXIncrement,
                                            int* OffsetYIncrement);

        /** Reset timestamp counter
         *  The camera's timestamp counter will be set to zero.
         *
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @return success or error code
         */
        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
        SVSGigeApiReturn
          Camera_resetTimestampCounter(int hCamera);

        /** Get timestamp counter
         *  Current value of the camera's timestamp counter will be returned.
         *
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param TimestampCounter the current value of the timestamp counter
         *  @return success or error code
         */
        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
        SVSGigeApiReturn
          Camera_getTimestampCounter(int hCamera,
                                     double* TimestampCounter);

        /** Get timestamp tick frequency
         *  A camera's timestamp tick frequency will be returned.
         *
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param TimestampTickFrequency the camera's timestamp tick frequency
         *  @return success or error code
         */
        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
        SVSGigeApiReturn
          Camera_getTimestampTickFrequency(int hCamera,
                                           double* TimestampCounter);



        //------------------------------------------------------------------------------
        // 21 - Controlling camera: Image appearance
        //------------------------------------------------------------------------------

        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
            SVSGigeApiReturn
            Camera_getPixelType(int hCamera,
            GVSP_PIXEL_TYPE* PixelType);

        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
            SVSGigeApiReturn
            Camera_setPixelDepth(int hCamera,
            SVGIGE_PIXEL_DEPTH PixelDepth);

        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
            SVSGigeApiReturn
            Camera_getPixelDepth(int hCamera, SVGIGE_PIXEL_DEPTH* PixelDepth);




        /** setWhiteBalance.
         *  The provided values will be applied for white balance.
         *
         *  NOTE: The color component strength for Red, Green and Blue can either be
         *        provided by user or they can conveniently be calculated inside an image
         *        callback using the Image_estimateWhiteBalance() function.
         *
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param Red balanced value for red color
         *  @param Green balanced value for green color
         *  @param Blue balanced value for blue color
         *  @return success or error code
         */
        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
            SVSGigeApiReturn
            Camera_setWhiteBalance(int hCamera,
            float Red,
            float Green,
            float Blue);

        /** getWhiteBalance.
         *  Currently set values for white balance will be returned.
         *  Previously adjusted values will be returned either unchanged or adjusted
         *  if necessary. The returned values will be 100 and above where the color
         *  which got 100 assigned will be transferred unchanged, however two
         *  other color components might be enhanced above 100 for each image.
         *
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param Red balanced value for red color
         *  @param Green balanced value for green color
         *  @param Blue balanced value for blue color
         *  @return success or error code
         */
        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
            SVSGigeApiReturn
            Camera_getWhiteBalance(int hCamera,
            float* Red,
            float* Green,
            float* Blue);

        /** getWhiteBalanceMax.
         *  The maximal white-balance value for amplifying colors will be returned.
         *  A value of 1.0 is the reference for a balanced situation.
         *
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param WhiteBalanceMax the maximal white-balance (e.g. 4.0 or 2.0)
         *  @return success or error code
         */
        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
            SVSGigeApiReturn
            Camera_getWhiteBalanceMax(int hCamera,
            float* WhiteBalanceMax);

        /** setGammaCorrection.
         *  A lookup table will be generated based on given gamma correction.
         *  Subsequently the lookup table will be uploaded to the camera.
         *  A gamma correction is supported in a range 0.4 - 2.5
         *
         *  @param Camera a handle from a camera that has been opened before
         *  @param GammaCorrection a gamma correction factor
         *  @return SVGigE_SUCCESS or an appropriate SVGigE error code
         */
        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
            SVSGigeApiReturn
            Camera_setGammaCorrection(int Camera,
            float GammaCorrection);

        /** setGammaCorrectionExt.
         *  A lookup table will be generated based on given gamma correction.
         *  Additionally, a digital gain and offset will be taken into account.
         *  Subsequently the lookup table will be uploaded to the camera.
         *  A gamma correction is supported in a range 0.4 - 2.5
         *
         *  @param Camera a handle from a camera that has been opened before
         *  @param GammaCorrection a gamma correction factor
         *  @return SVGigE_SUCCESS or an appropriate SVGigE error code
         */
        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
            SVSGigeApiReturn
            Camera_setGammaCorrectionExt(int Camera,
            float GammaCorrection,
            float DigitalGain,
            float DigitalOffset);

        /** setLowpassFilter.
          *  A filter will be enabled/disabled which smoothes an image inside
          *  a camera accordingly to a given algorithm, e.g. 3x3.
          *
          *  @param Camera a handle from a camera that has been opened before
          *  @param LowpassFilter a control value for activating/deactivating smoothing
          *  @return SVGigE_SUCCESS or an appropriate SVGigE error code
          */
        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
            SVSGigeApiReturn
            Camera_setLowpassFilter(int Camera,
            LOWPASS_FILTER LowpassFilter);

        /** getLowpassFilter.
          *  Current mode of a lowpass filter will be retrieved from camera.
          *
          *  @param Camera a handle from a camera that has been opened before
          *  @param LowpassFilter the currently programmed lowpass filter will be returned
          *  @return SVGigE_SUCCESS or an appropriate SVGigE error code
          */
        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
            SVSGigeApiReturn
            Camera_getLowpassFilter(int Camera,
            LOWPASS_FILTER* ProgrammedLowpassFilter);

        /** setLookupTableMode.
         *  The look-up table mode will be switched on or off
         *
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param LUTMode new setting for look-up table mode
         *  @return success or error code
         */
        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
            SVSGigeApiReturn
            Camera_setLookupTableMode(int hCamera,
            LUT_MODE LUTMode);

        /** Get look-up table mode.
         *  The currently programmed look-up table mode will be retrieved
         *
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param ProgrammedLUTMode currently programmed look-up table mode
         *  @return success or error code
         */
        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
            SVSGigeApiReturn
            Camera_getLookupTableMode(int hCamera,
            LUT_MODE* ProgrammedLUTMode);

        /** setLookupTable.
         *  A user-defined lookup table will be uploaded to the camera. The size has to match
         *  the lookup table size that is supported by the camera (1024 for 10to8 or 4096 for 12to8).
         *
         *  @see Camera_isCameraFeature()
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param LookupTable an array of user-defined lookup table values (bytes)
         *  @param LookupTableSize the size of the user-defined lookup table
         *  @return success or error code
         */
        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
            SVSGigeApiReturn
            Camera_setLookupTable(int hCamera,
            sbyte* LookupTable,
            int LookupTableSize);

        /** getLookupTable.
         *  The currently installed lookup table will be downloaded from the camera. The size of the
         *  reserved download space has to match the lookup table size (1024 for 10to8 or 4096 for 12to8).
         *
         *  @see Camera_isCameraFeature()
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param ProgrammedLookupTable an array for downloading the lookup table from camera
         *  @param LookupTableSize the size of the provided lookup table space
         *  @return success or error code
         */
        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
            SVSGigeApiReturn
            Camera_getLookupTable(int hCamera,
            sbyte* ProgrammedLookupTable,
            int LookupTableSize);


        /** startImageCorrection.
         *  A particular step inside of acquiring a correction image for either,
           *  flat field correction (FFC) or shading correction will be started:
           *    - acquire a black image
           *    - acquire a white image
           *    - save a correction image to camera's persistent memory
           *
         *  @see Camera_isCameraFeature()
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param ImageCorrectionStep a particular step from running an image correction
         *  @return success or error code
           */
        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
            SVSGigeApiReturn
            Camera_startImageCorrection(int hCamera,
            IMAGE_CORRECTION_STEP ImageCorrectionStep);

        /** isIdleImageCorrection.
         *  A launched image correction processs will be checked whether a recently
           *  initiated image correction step has be finished:
           *    - acquire a black image
           *    - acquire a white image
           *    - save a correction image to camera's persistent memory
           *
         *  @see Camera_isCameraFeature()
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param ImageCorrectionStep a particular step from running an image correction
         *  @return success or error code
           */
        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
            SVSGigeApiReturn
            Camera_isIdleImageCorrection(int hCamera,
            IMAGE_CORRECTION_STEP* ProgrammedImageCorrectionStep,
            bool* isIdle);

        /** setImageCorrection.
         *  A camera will be switched to one of the following image correction modes
           *    - None (image correction is off)
           *    - Offset only (available for Flat Field Correction, FFC)
           *    - Enabled (image correction is on)
           *  If image correction is enabled, then it depends on the camera whether 
           *  Flat Field Correction (FFC) is enabled (gain and offset for each pixel) 
           *  or Shading Correction (gain interpolation for a group of adjacent pixels)
           *
         *  @see Camera_isCameraFeature()
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param ImageCorrectionMode one of above image correction modes
         *  @return success or error code
           */
        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
            SVSGigeApiReturn
            Camera_setImageCorrection(int hCamera,
            IMAGE_CORRECTION_MODE ImageCorrectionMode);

        /** getImageCorrection.
         *  A camera will be queried for current image correction mode, either of:
           *    - None (image correction is off)
           *    - Offset only (available for Flat Field Correction, FFC)
           *    - Enabled (image correction is on)
           *  If image correction is enabled, then it depends on the camera whether 
           *  Flat Field Correction (FFC) is enabled (gain and offset for each pixel) 
           *  or Shading Correction (gain interpolation for a group of adjacent pixels)
           *
         *  @see Camera_isCameraFeature()
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param ProgrammedImageCorrectionMode one of above image correction modes
         *  @return success or error code
           */
        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
            SVSGigeApiReturn
            Camera_getImageCorrection(int hCamera,
            IMAGE_CORRECTION_MODE* ProgrammedImageCorrectionMode);


        //------------------------------------------------------------------------------
        // 22 -  Special Control: IOMux configuration
        //------------------------------------------------------------------------------

        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
            SVSGigeApiReturn
            Camera_getMaxIOMuxIN(int hCamera, int* MaxIOMuxINSignals);



        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
            SVSGigeApiReturn
            Camera_getMaxIOMuxOUT(int hCamera, int* MaxIOMuxOUTSignals);



        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
            SVSGigeApiReturn
            Camera_setIOAssignment(int hCamera,
            SVGigE_IOMux_OUT IOMuxOUT,
            SVGigE_IOMux_IN SignalIOMuxIN);



        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
            SVSGigeApiReturn
            Camera_getIOAssignment(int hCamera,
            SVGigE_IOMux_OUT IOMuxOUT,
            uint* ProgrammedIOMuxIN);



        //------------------------------------------------------------------------------
        // 23 - Special Control: IO control
        //------------------------------------------------------------------------------


        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
            SVSGigeApiReturn
            Camera_setIOMuxIN(int hCamera,
            uint VectorIOMuxIN);



        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
            SVSGigeApiReturn
            Camera_getIOMuxIN(int hCamera,
            uint* ProgrammedVectorIOMuxIN);




        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
            SVSGigeApiReturn
            Camera_setIO(int hCamera,
            SVGigE_IOMux_IN SignalIOMuxIN,
            SVGigE_IO_Signal SignalValue);





        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
            SVSGigeApiReturn
            Camera_getIO(int hCamera,
            SVGigE_IOMux_IN SignalIOMuxIN,
            SVGigE_IO_Signal* ProgrammedSignalValue);


        /** setAcqLEDOverride.
         *  Override default LED mode by an alternative behavior:
         *  - blue:    waiting for trigger
         *  - cyan:    exposure
         *  - magenta: read-out
         *
         *  @see Camera_isCameraFeature()
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param isOverrideActive whether LED override will be activated or deactivated
         *  @return success or error code
         */
        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
            SVSGigeApiReturn
            Camera_setAcqLEDOverride(int hCamera,
            bool isOverrideActive);

        /** getAcqLEDOverride.
         *  Check whether default LED mode was overridden by an alternative behavior:
         *  - blue:    waiting for trigger
         *  - cyan:    exposure
         *  - magenta: read-out
         *
         *  @see Camera_isCameraFeature()
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param isOverrideActive a flag indicating whether LED override is currently activated
         *  @return success or error code
         */
        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
            SVSGigeApiReturn
            Camera_getAcqLEDOverride(int hCamera,
            bool* isOverrideActive);

        /** setLEDIntensity.
         *  The LED intensity will be controlled in the range 0..255 as follows:
         *  0   - dark
         *  255 - light
         *
         *  @see Camera_isCameraFeature()
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param LEDIntensity the new intensity (0..255=max) to be assigned to the LED
         *  @return success or error code
         */
        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
            SVSGigeApiReturn
            Camera_setLEDIntensity(int hCamera,
            int LEDIntensity);

        /** getLEDIntensity.
         *  The LED intensity will be retrieved from camera with the following meaning:
         *  0   - dark
         *  255 - light
         *
         *  @see Camera_isCameraFeature()
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param ProgrammedLEDIntensity currently assigned LED intensity
         *  @return success or error code
         */
        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
            SVSGigeApiReturn
            Camera_getLEDIntensity(int hCamera,
            int* ProgrammedLEDIntensity);

        //------------------------------------------------------------------------------
        // 24 - Special control: Serial communication
        //------------------------------------------------------------------------------

        /** setUARTBuffer.
         *  A block of data (max 512 bytes) will be sent to the camera's UART for
         *  transmitting it over the serial line to a receiver.
         *
         *  @see Camera_isCameraFeature()
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param Data a pointer to a block of data to be sent over the camera's UART
         *  @param the length of the data block (1..512)
         *  @return success or error code
         */
        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
            SVSGigeApiReturn
            Camera_setUARTBuffer(int hCamera, sbyte* Data, int DataLength);

        /** getUARTBuffer.
         *  A block of data will be retrieved which has arrived in the camera's UART
         *  receiver buffer. If this function returns the maximal possible byte
         *  count then there might be more data available which should be retrieved
         *  by a subsequent call to this function.
         *
         *  @see Camera_isCameraFeature()
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param Data a pointer to a data buffer
         *  @param DataLengthReceived a pointer to a value for returning actual data read
         *  @param DataLengthMax the maximal data length to be read (1..512)
         *  @param Timeout a time period [s] after which the function returns if no data was received
         *  @return success or error code
         */
        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
            SVSGigeApiReturn
            Camera_getUARTBuffer(int hCamera,
            sbyte* Data,
            int* DataLengthReceived,
            int DataLengthMax,
            float Timeout);

        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
            SVSGigeApiReturn
            Camera_setUARTBaud(int hCamera, SVGigE_BaudRate BaudRate);

        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
            SVSGigeApiReturn
            Camera_getUARTBaud(int hCamera, SVGigE_BaudRate* ProgrammedBaudRate);




        //------------------------------------------------------------------------------
        // 25 - Special control: Direct register and memory access
        //------------------------------------------------------------------------------

        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
            SVSGigeApiReturn
            Camera_setGigECameraRegister(int hCamera,
            uint RegisterAddress,
            uint RegisterValue,
            uint GigECameraAccessKey);

        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
            SVSGigeApiReturn
            Camera_getGigECameraRegister(int hCamera,
            uint RegisterAddress,
            uint* ProgammedRegisterValue,
            uint GigECameraAccessKey);



        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
            SVSGigeApiReturn
            Camera_writeGigECameraMemory(int hCamera,
            uint MemoryAddress,
            sbyte* DataBlock,
            uint DataLength,
            uint GigECameraAccessKey);


        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
            SVSGigeApiReturn
            Camera_readGigECameraMemory(int hCamera,
            uint MemoryAddress,
            sbyte* DataBlock,
            uint DataLength,
            uint GigECameraAccessKey);


        //------------------------------------------------------------------------------
        // 26 - Special control: Persistent settings and recovery
        //------------------------------------------------------------------------------

        /**
         * Write EEPROM defaults.
         * The current settings will be made the EEPROM defaults that will be
         * restored on each camera start-up
         *
         * @see CameraContainer_getCamera()
         * @param hCamera a camera handle received from CameraContainer_getCamera()
         * @return success or error code
         */
        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
            SVSGigeApiReturn
            Camera_writeEEPROM(int hCamera);


        /**
         * Read EEPROM defaults.
         * The EEPROM content will be moved to the appropriate camera registers.
         * This operation will restore the camera settings that were active when
         * the EEPROM write function was performed
         *
         * @see CameraContainer_getCamera()
         * @param hCamera a camera handle received from CameraContainer_getCamera()
         * @return success or error code
         */
        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
            SVSGigeApiReturn
            Camera_readEEPROM(int hCamera);


        /**
         * Restore factory defaults.
         * The camera's registers will be restored to the factory defaults and at
         * the same time those settings will be written as default to EEPROM
         *
         * @see CameraContainer_getCamera()
         * @param hCamera a camera handle received from CameraContainer_getCamera()
         * @return success or error code
         */
        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
            SVSGigeApiReturn
            Camera_restoreFactoryDefaults(int hCamera);


        /** Load settings from XML
         *  New camera settings will be loaded from a XML file.
         *  The  XML file content will be moved to the appropriate camera registers.
         *  In this operation the XML file will be used instead of the EEPROM. 
         *  
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param Filename a complete path and filename where to load the settings from
         *  @return success or error code
         */
        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
            SVSGigeApiReturn
            Camera_loadSettingsFromXml(int hCamera,
            String Filename);

        /** Save settings to XML
         *  The current settings will be stored in a XML file 
         *  In this operation the XML file will be used instead of the EEPROM. 
         *
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param Filename a complete path and filename where to write the new settings.
         *  @return success or error code
         */
        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
            SVSGigeApiReturn
            Camera_SaveSettingsToXml(int hCamera,
            String Filename);


        //------------------------------------------------------------------------------
        // 27 - General functions
        //------------------------------------------------------------------------------

        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
            SVSGigeApiReturn
            SVGigE_estimateWhiteBalance(sbyte* BufferRGB,
            int BufferLength,
            float* Red,
            float* Green,
            float* Blue);


        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
            SVSGigeApiReturn
            SVGigE_writeImageToBitmapFile(sbyte* Filename, sbyte* Data, int SizeX, int SizeY, GVSP_PIXEL_TYPE PixelType);


        /** Install a filter driver
         *  A filter driver will be installaed automatically for current system platform
         *  which may be WinXP x86/x64 or Win7 x86/64.
         *  The location of the driver package can be provided by function argument.
         *  If not, a default location will be supposed for particular driver files.
         *  If the driver location is provided then that location has to contain the
         *  platform folders for WinXP x86/x64 and Win7 x86/x64 except when the name
         *  of the .inf file is also provided. In the latter case the path has to 
         *  point to the folder where the .inf file can be found.
         *
         *  @param PathToDriverPackege (optional) the full path to driver packages (excluding platform folders)
         *  @param FilenameINF (optional) the name of an INF file to install for the protocol edge
         *  @param FilenameINF_m (optional) the name of an INF file to install for the miniport edge
         *  @return a success or failure code
         */
        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
            SVSGigeApiReturn
            SVGigE_installFilterDriver(sbyte* PathToDriverPackage, sbyte* FilenameINF, sbyte* FilenameINF_m);

        /** De-install filter driver
         *  A SVGigE filter driver component will be located in the system and if it
         *  is present then it will be uninstalled.
         *
         *  @return a success or failure code
         */
        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
            SVSGigeApiReturn
            SVGigE_uninstallFilterDriver();




        //------------------------------------------------------------------------------
        // 28 - Diagnostics
        //------------------------------------------------------------------------------

        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
            sbyte*
            _Error_getMessage(SVSGigeApiReturn ReturnCode);



        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
            SVSGigeApiReturn
            Camera_registerForLogMessages(int hCamera, int LogLevel, sbyte* LogFilename,
            LogMessageCallback LogCallback, void* MessageContext);




        /**********************************************************************/


        /**********************************************************************/

        //------------------------------------------------------------------------------------------------------------------------------------------
        //------------------------------------------------------------------------------------------------------------------------------------------
        //------------------------------------------------------------------------------------------------------------------------------------------		  

        /** Streaming channel callback function.
        *  The user-defined streaming channel callback function will be called each
        *  time when an image acquisition from camera has been finished and the image
        *  is ready for processing
        *
        *  NOTE: The callback function will return a NULL pointer in case an image
        *        could not be completely received over the network due to a timeout,
        *        e.g. in the result of insufficient bandwidth
        */

        // typedef SVGigE_RETURN (__stdcall *StreamCallback)(Image_handle Image, void* Context);

        public delegate SVSGigeApiReturn StreamCallback([MarshalAs(UnmanagedType.I4)] int Image, [MarshalAs(UnmanagedType.I4)] int Context);


        /** Messaging channel callback function.
         *  The user-defined messaging channel callback function will be called each time
         *  when an event was signaled which arrived from a camera or from intermediate software
         *  layers.
         *
         *  An application should retrieve, process appropriately and finally release any message
         *  that has arrived when the event callback function gets control. There might be one or
         *  multiple messages waiting for processing in a FIFO on entry to the callback function.
         *
         *  HINT: If the size of the FIFO was not sufficient for handling all messages that
         *  arrived from one callback to the next callback then an exception will be raised.
         *  An application must catch this exception and should react with an appropriate
         *  user message, log entry or the like which informs an operator about this
         *  exceptional situation.
         */
        //typedef SVGigE_RETURN (__stdcall *EventCallback)(Event_handle EventID, void* Context);

        public delegate SVSGigeApiReturn EventCallback([MarshalAs(UnmanagedType.I4)] int EventID, [MarshalAs(UnmanagedType.I4)] int Context);


        /** Register for log messages.
         *  Log messages can be requested for various log levels:
         *  0 - logging off
         *  1 - CRITICAL errors that prevent from further operation
         *  2 - ERRORs that prevent from proper functioning
         *  3 - WARNINGs which usually do not affect proper work
         *  4 - INFO for listing camera communication (default)
         *  5 - DIAGNOSTICS for investigating image callbacks
         *  6 - DEBUG for receiving multiple parameters for image callbacks
         *  7 - DETAIL for receiving multiple signals for each image callback
         *
         *  Resulting log messages can be either written into a log file
         *  respectively they can be received by a callback and further
         *  processed by an application.
         *
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param LogLevel one of the above log levels
         *  @param LogFilename a filename where all log messages will be written to or NULL
         *  @param LogCallback a callback function that will receive all log messages or NULL
         *  @param MessageContext a context that will be returned to application with each callback or NULL
         *  @return success or error code
         */

        public delegate SVSGigeApiReturn LogMessageCallback([MarshalAs(UnmanagedType.I4)] sbyte LogMessage, [MarshalAs(UnmanagedType.I4)] int MessageContext);

        //typedef void (__stdcall *LogMessageCallback)(char *LogMessage, void *MessageContext);






        //------------------------------------------------------------------------------
        // Camera container
        //------------------------------------------------------------------------------
        /** public static int myStreamCallback(int Image, int Context)
        {
            callbackCount++;
            //return SVSGigeApiReturn.SVS_GigE_API_ERROR;
            return 0;
        }
        */
        /**
         * Create camera container.
         * A handle is obtained that references a management object for discovering
         * and selecting GigE cameras in the network segments that a computer is
         * connected to.
         *
         * @return on success a handle for subsequent camera container function calls
         *         or -1 if creating a camera container failed
         */
        public unsafe
            int
            Gige_CameraContainer_create(SVGigETL_Type TransportLayerType)
        {
            return (CameraContainer_create(TransportLayerType));
        }

        /**
         * Delete Camera container.
         * A previously created camera container reference will be released. After
         * deleting a camera container all camera specific functions are no longer
         * available
         *
         * @param hCameraContainer a handle received from CameraContainer_create()
         */
        public unsafe
            void
            Gige_CameraContainer_delete(int hCameraContainer)
        {
            CameraContainer_delete(hCameraContainer);
        }

        /**
         * Device discovery.
         * All network segments that a computer is connected to will be serached for
         * GigE cameras by sending out a network broadcast and subsequently analyzing
         * camera responses.
         *
         * @param hCameraContainer a handle received from CameraContainer_create()
         * @return success or error code
         */
        public unsafe
            SVSGigeApiReturn
            Gige_CameraContainer_discovery(int hCameraContainer)
        {
            return CameraContainer_discovery(hCameraContainer);
        }

        /**
         * Get number of connected cameras.
         * The maximal index is returned that cameras can be accessed with in the
         * camera container
         *
         * @param hCameraContainer a handle received from CameraContainer_create()
         * @return number of available cameras
         */
        public unsafe
            int
            Gige_CameraContainer_getNumberOfCameras(int hCameraContainer)
        {
            return CameraContainer_getNumberOfCameras(hCameraContainer);
        }

        /**
         * Get camera.
         * A camera handle is obtained accordingly to an index that was specified
         * as an input parameter
         *
         * @param hCameraContainer a handle received from CameraContainer_create()
         * @param CameraIndex camera index from zero to one less the number of available cameras
         * @return a handle for subsequent camera function calls or NULL in case the
         *         index was specified out of range
         */
        public unsafe
            int
            Gige_CameraContainer_getCamera(int hCameraContainer,
            int CameraIndex)
        {
            this.hCamera = CameraContainer_getCamera(hCameraContainer, CameraIndex);
            return hCamera;
        }

        //------------------------------------------------------------------------------
        // Camera
        //------------------------------------------------------------------------------

        /**
         * Open connection to camera.
         * A TCP/IP control channel will be established.
         *
         * @see CameraContainer_getCamera()
         * @param hCamera a camera handle received from CameraContainer_getCamera()
         * @return success or error code
         */
        public unsafe
            SVSGigeApiReturn
            Gige_Camera_openConnection(int hCamerax, float timeout)
        {
            //this.hCamera = hCamera;
            return Camera_openConnection(hCamerax, (float)timeout);
        }

        /**
         * Disconnect camera.
         * The TCP/IP control channel will be closed
         *
         * @see CameraContainer_getCamera()
         * @param hCamera a camera handle received from CameraContainer_getCamera()
         * @return success or error code
         ****/
        public unsafe
            SVSGigeApiReturn
            Gige_Camera_closeConnection(int hCamera)
        {
            return Camera_closeConnection(hCamera);
        }


        /** Set IP address.
         *  The camera will get a new persistent IP address assigned. If the camera
         *  is currently unavailable in the subnet where it is attached to, then a
         *  temporary IP address will be forced into the camera first. In any case
         *  the camera will have the new IP address assigned as a persistent IP 
         *  which will apply after camera's next reboot.
         *
         *  HINT:
         *  If an IP address is set that is not inside the subnet where the camera
         *  is currently connected to, then the camera becomes unavailable after next
         *  reboot. This can be avoided by having a valid IP address assigned automatically 
         *  by setting both values to zero, IPAddress and NetMask
         *
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param IPAddress a valid IP address or zero (for automatically assigning a valid IP/netmask)
         *  @param NetMask a matching net mask or zero (for automatically assigning a valid IP/netmask)
         *  @return success or error code
         */


        public unsafe
        SVSGigeApiReturn
        Gige_Camera_setIPAddress(int hCamera, uint IPAddress, uint NetMask)
        {
            return Camera_setIPAddress(hCamera, IPAddress, NetMask);
        }



        /** Force valid network settings
         *  A camera's availability will be evaluated. If it is outside current subnet 
         *  then it will be forced to valid network settings inside current subnet. 
         *  Valid network settings will be reported back to caller.
         *
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param IPAddress the new IP address that has been selected and forced
         *  @param NetMask the new subnet mask that has been selected and forced
         *  @return success or error code
         *
         *  HINT: If the return code is SVGigE_SVCAM_STATUS_CAMERA_OCCUPIED then the 
         *        IPAdress will show the IP of the host that occupies the camera.
         */
        //public unsafe
        //SVSGigeApiReturn
        //Gige_Camera_forceValidNetworkSettings(int hCamera, ref uint IPAddress, ref uint SubnetMask)
        //{
        //    SVSGigeApiReturn rval;
        //    fixed (uint* iP = &IPAddress,mask=&SubnetMask)
        //    {
        //        rval=Camera_forceValidNetworkSettings(hCamera, iP, mask);
        //    }
        //    return rval;
        //}

        public unsafe
        SVSGigeApiReturn
        Gige_Camera_forceValidNetworkSettings(int hCamera, uint* IPAddress, uint* SubnetMask)
        {
            return Camera_forceValidNetworkSettings(hCamera, IPAddress, SubnetMask);
        }

        //---Camera-information---------------------------------------------------------

        /**
             * Get manufacturer name.
             * The manufacturer name that is obtained from the camera firmware will be
             * returned
             *
             * @see CameraContainer_getCamera()
             * @param hCamera a camera handle received from CameraContainer_getCamera()
             * @return a string containing requested information
             */
        public unsafe
            string
            Gige_Camera_getManufacturerName(int hCamera)
        {
            sbyte* strPtr;
            string rstring;
            strPtr = Camera_getManufacturerName(hCamera);
            rstring = new string(strPtr);
            return rstring;

        }

        public unsafe int Gige_CameraContainer_findCamera(int hCameraContainer,
            string serialNO)
        {
            //sbyte CameraItem = sbyte.Parse(serialNO);
            sbyte[] sbArray = (sbyte[])((Array)System.Text.Encoding.Default.GetBytes(serialNO));
            //用这行代码将字符串转为sbyte[]型 fixed (sbyte* psb = sbArray) 
            fixed (sbyte* CameraItem = sbArray)
            {
                return (int)CameraContainer_findCamera(hCameraContainer, CameraItem);
            }
        }

        /**
             * Get model name.
             * The model name that is obtained from the camera firmware will be
             * returned
             *
             * @see CameraContainer_getCamera()
             * @param hCamera a camera handle received from CameraContainer_getCamera()
             * @return a string containing requested information
             */
        public unsafe
            string
            Gige_Camera_getModelName(int hCamera)
        {
            sbyte* ascii;
            string rstring;
            ascii = Camera_getModelName(hCamera);
            rstring = new string(ascii);
            return rstring;

        }
        public unsafe void
            Gige_Camera_getModelNameBytes(int hCamera, byte[] buffer)
        {
            int k = 0;
            sbyte* ascii;
            ascii = Camera_getModelName(hCamera);
            while (*ascii != 0)
            {
                buffer[k] = (byte)(*ascii);
                ascii++;
                k++;
            }

        }
        /**
             * Get device version.
             * The device version that is obtained from the camera firmware will be
             * returned
             *
             * @see CameraContainer_getCamera()
             * @param hCamera a camera handle received from CameraContainer_getCamera()
             * @return a string containing requested information
             */
        public unsafe
            string
            Gige_Camera_getDeviceVersion(int hCamera)
        {
            sbyte* ascii;
            string rstring;
            ascii = Camera_getDeviceVersion(hCamera);
            rstring = new string(ascii);
            return rstring;

        }

        /**
             * Get manufacturer specific information.
             * The manufacturer specific information that is obtained from the camera
             * firmware will be returned
             *
             * @see CameraContainer_getCamera()
             * @param hCamera a camera handle received from CameraContainer_getCamera()
             * @return a string containing requested information
             */
        public unsafe
            string
            Gige_Camera_getManufacturerSpecificInformation(int hCamera)
        {
            sbyte* ascii;
            string rstring;
            ascii = Camera_getManufacturerSpecificInformation(hCamera);
            rstring = new string(ascii);
            return rstring;


        }

        /**
             *  Get serial number.
             *  The (manufacturer-assigned) serial number will be obtained from the camera
             *
             * @see CameraContainer_getCamera()
             * @param hCamera a camera handle received from CameraContainer_getCamera()
             * @return a string containing requested information
             */
        public unsafe
            string
            Gige_Camera_getSerialNumber(int hCamera)
        {
            sbyte* ascii;
            string rstring;
            ascii = Camera_getSerialNumber(hCamera);
            rstring = new string(ascii);
            return rstring;

        }

        /**
             *  Set user-defined name
             *  A user-defined name will be assigned permanently to a camera
             *
             * @see CameraContainer_getCamera()
             * @param hCamera a camera handle received from CameraContainer_getCamera()
             * @param UserDefinedName the name to be transferred to the camera
             * @return success or error code
             */
        public unsafe
            SVSGigeApiReturn
            Gige_Camera_setUserDefinedName(int hCamera, sbyte* UserDefinedName)
        {
            return Camera_setUserDefinedName(hCamera, UserDefinedName);
        }

        /**
             *  Get user-defined name
             *  A name that has been assigned to a camera by the user will be returned
             *
             * @see CameraContainer_getCamera()
             * @param hCamera a camera handle received from CameraContainer_getCamera()
             * @return a string containing requested information
             */
        public unsafe
            string
            Gige_Camera_getUserDefinedName(int hCamera)
        {
            sbyte* ascii;
            string rstring;
            ascii = Camera_getUserDefinedName(hCamera);
            rstring = new string(ascii);
            return rstring;


        }

        /**
             * Get MAC address.
             * The MAC address that is obtained from the camera firmware will be returned
             *
             * @see CameraContainer_getCamera()
             * @param hCamera a camera handle received from CameraContainer_getCamera()
             * @return a string containing requested information
             */
        public unsafe
            string
            Gige_Camera_getMacAddress(int hCamera)
        {
            sbyte* ascii;
            string rstring;
            ascii = Camera_getMacAddress(hCamera);
            rstring = new string(ascii);
            return rstring;

        }

        /**
             * Get IP address.
             * The IP address that the camera is currently working on will be returned
             *
             * @see CameraContainer_getCamera()
             * @param hCamera a camera handle received from CameraContainer_getCamera()
             * @return a string containing requested information
             */
        public unsafe
            string
            Gige_Camera_getIPAddress(int hCamera)
        {
            sbyte* ascii;
            string rstring;
            ascii = Camera_getIPAddress(hCamera);
            rstring = new string(ascii);
            return rstring;

        }


        /** Get subnet mask.
         *  The subnet mask that the camera is currently working with will be returned
         *
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @return success or error code
         */

        public unsafe
          string
            Gige_Camera_getSubnetMask(int hCamera)
        {
            sbyte* ascii;
            string rstring;
            ascii = Camera_getSubnetMask(hCamera);
            rstring = new string(ascii);
            return rstring;
        }


        /** Get pixel clock.
         *  The camera's pixel clock will be returned
         *
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param PixelClock a reference to the pixel clock value
         *  @return success or error code
         */
        public unsafe
            SVSGigeApiReturn
        Gige_Camera_getPixelClock(int hCamera,
                   ref int PixelClock)
        {
            SVSGigeApiReturn rval;
            fixed (int* clockPtr = &PixelClock)
            {
                rval = Camera_getPixelClock(hCamera, clockPtr);
            }
            return rval;
        }

        /** Read XML file.
         *  The camera's XML file will be retrieved and made available for further
         *  processing by an application. The returned pointer to the content of the
         *  XML file will be valid until the function is called again or until
         *  the camera is closed.
         *
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param XML a pointer to a zero-terminated string containing the complete XML file
         *  @return success or error code
         */
        public unsafe
            SVSGigeApiReturn
              Gige_Camera_readXMLFile(int hCamera, char** XML)
        {
            SVSGigeApiReturn rval;
            rval = Camera_readXMLFile(hCamera, XML);

            return rval;

        }













        //------------------------------------------------------------------------------
        // 20 - Special control: IOMux configuration
        //------------------------------------------------------------------------------


















        //------------------------------------------------------------------------------
        // 21 - Special control: IO control
        //------------------------------------------------------------------------------






        //------------------------------------------------------------------------------
        //------------------------------------------------------------------------------

        /**
           * Is camera feature.
           * The camera will be queried whether a feature is available or not.
           *
           * @see CameraContainer_getCamera()
           * @param hCamera a camera handle received from CameraContainer_getCamera()
           * @param Feature a feature which availability will be determined
           * @return a boolean value indicating whether the queried feature is available or not
           */
        public unsafe bool
            Gige_Camera_isCameraFeature(int hCamera, CAMERA_FEATURE Feature)
        {
            return Camera_isCameraFeature(hCamera, Feature);
        }




        public unsafe
        SVSGigeApiReturn
        Gige_Camera_getSensorTemperature(int hCamera,
         uint* SensorTemperature)
        {
            return Camera_getSensorTemperature(hCamera,
              SensorTemperature);
        }




        //---Main-camera-control-(framerate,exposure,gain)------------------------------




        //---Look-up-table-/-Binning----------------------------------------------------

        /**
             * Set look-up table mode.
             * The look-up table mode will be switched on or off
             *
             * @see CameraContainer_getCamera()
             * @param hCamera a camera handle received from CameraContainer_getCamera()
             * @param LUTMode new setting for look-up table mode
             * @return success or error code
             */
        public unsafe
            SVSGigeApiReturn
            Gige_Camera_setLUTMode(int hCamera, LUT_MODE LUTMode)
        {
            return Camera_setLUTMode(hCamera, LUTMode);
        }

        /**
             * Get look-up table mode.
             * The currently programmed look-up table mode will be retrieved
             *
             * @see CameraContainer_getCamera()
             * @param hCamera a camera handle received from CameraContainer_getCamera()
             * @param ProgrammedLUTMode currently programmed look-up table mode
             * @return success or error code
             */
        public unsafe
            SVSGigeApiReturn
            Gige_Camera_getLUTMode(int hCamera,
            LUT_MODE* ProgrammedLUTMode)
        {
            return Camera_getLUTMode(hCamera, ProgrammedLUTMode);
        }

        /**
             * Create look-up table.
             * A new look-up table will be created based on three values for red, green
             * and blue color
             *
             * @see CameraContainer_getCamera()
             * @param hCamera a camera handle received from CameraContainer_getCamera()
             * @param Red new value 0..255 for red color
             * @param Green new value 0..255 for green color
             * @param Blue new value 0..255 for blue color
             * @return success or error code
             */
        public unsafe
            SVSGigeApiReturn
            Gige_Camera_createLUTwhiteBalance(int hCamera,
            float Red,
            float Green,
            float Blue)
        {
            return Camera_createLUTwhiteBalance(hCamera, Red, Green, Blue);
        }

        //---Acquisition-modes-(trigger)------------------------------------------------

        /**
             * Start acquisition cycle.
             * The camera will be triggerred for starting a new acquisition cycle.
             * A mandatory pre-requisition for successfully starting an acquisition
             * cycle by software is to have the camera set to SVSGige_CameraCodes_INT_TIGGER
             * before
             *
             * @see CameraContainer_getCamera()
             * @param hCamera a camera handle received from CameraContainer_getCamera()
             * @return success or error code
             */
        public unsafe
            SVSGigeApiReturn
            Gige_Camera_startAcquisitionCycle(int hCamera)
        {
            return Camera_startAcquisitionCycle(hCamera);
        }



        //---Timestamps-----------------------------------------------------------------

        /**
             * Stamp timestamp.
             * A hardware timestamp will be written into the selected camera register.
             * The timestamp's actual value can be read out by Camera_getTimestamp()
             *
             * @see CameraContainer_getCamera()
             * @param hCamera a camera handle received from CameraContainer_getCamera()
             * @param TimestampIndex the index of the timestamp to be set by hardware
             * @return success or error code
             */
        public unsafe
            SVSGigeApiReturn
            Gige_Camera_stampTimestamp(int hCamera,
            int TimestampIndex)
        {
            return Camera_stampTimestamp(hCamera, TimestampIndex);
        }

        /**
             * Get timestamp.
             * The value of a selected hardware timestamp will be returned. The index
             * provided to the function is valid in the range between 0 and 8
             *
             * @see CameraContainer_getCamera()
             * @param hCamera a camera handle received from CameraContainer_getCamera()
             * @param TimestampIndex the index of the timestamp to be returned
             * @param Timestamp the timestamp's value in seconds and part of a second
             * @return success or error code
             */
        public unsafe
            SVSGigeApiReturn
            Gige_Camera_getTimestamp(int hCamera,
            int TimestampIndex,
            double* Timestamp)
        {
            return Camera_getTimestamp(hCamera, TimestampIndex, Timestamp);
        }
        //---Expert functions-----------------------------------------------------------

        //------------------------------------------------------------------------------
        // Streaming channel
        //------------------------------------------------------------------------------

        /**
             * Create streaming channel.
             * A UDP streaming channel will be established for image data transfer.
             * A connection to the camera has to be successfully opened first using
             * Camera_openConnection() before a streaming channel can be established
             *
             * @see Camera_openConnection()
             * @param hStreamingChannel a handle for the streaming channel will be returned
             * @param hCameraContainer a camera container handle received from CameraContainer_create()
             * @param hCamera a camera handle received from CameraContainer_getCamera()
             * @param DriverEnabled specifies whether a filter driver will be used or not
             * @param CallbackFunction user-defined callback function for image processing
             * @param Context user-defined data that will be returned on each callback
             * @return a streaming channel handle for subsequent streaming channel function calls
             */
        public unsafe
            SVSGigeApiReturn
            Gige_StreamingChannel_create(ref int hStreamingChannel,
            int hCameraContainer,
            int hCamera,
            int BufferCount,
            StreamCallback CallbackFunction,
            int Context)
        {
            SVSGigeApiReturn rval;

            int ct = 0x7000000;
            fixed (int* hSC = &hStreamingChannel)
            {
                rval = StreamingChannel_create(hSC, hCameraContainer,
                     hCamera, BufferCount, CallbackFunction, (void*)ct);

            }


            return rval;
        }

        /**
             * Delete streaming channel.
             * A streaming channel will be closed and all resources will be released that
             * have been occupied by the streaming channel
             *
             * @param hStreamingChannel a streaming channel handle received from
             * StreamingChannel_create()
             * @return success or error code
             */
        public unsafe
            SVSGigeApiReturn
            Gige_StreamingChannel_delete(int hStreamingChannel)
        {
            SVSGigeApiReturn rval;

            rval = StreamingChannel_delete(hStreamingChannel);

            return rval;
        }


        /** Set channel timeout.
 *  An overall channel timeout will be set that is applied to the period from receiving a first
 *  data packet in an image stream (from any stream in case of MultiStream) and the completion 
 *  of the image (completion of the compound view in case of MultiStream). When the specified
 *  timeout is reached the streaming channel will send a NULL pointer to application in a
 *  registered before image callback function. Possible image data from any camera arriving 
 *  after timeout will be rejected. The channel will be ready for receiving a subsequent image.
 *
 *  @param hStreamingChannel a streaming channel handle received from StreamingChannel_create()
 *  @param ChannelTimeout the overall channel timeout between first data packet and image completion
 *  @return success or error code
 */
        public unsafe
          SVSGigeApiReturn
        Gige_StreamingChannel_setChannelTimeout(int hStreamingChannel,
                                           float ChannelTimeout)
        {
            SVSGigeApiReturn rval;

            rval = StreamingChannel_setChannelTimeout(hStreamingChannel, ChannelTimeout);

            return rval;
        }

        /** Get channel timeout.
         *  A channel's timeout will be queried and be returned to application.
         *
         *  @param hStreamingChannel a streaming channel handle received from StreamingChannel_create()
         *  @param ChannelTimeout the overall channel timeout between first data packet and image completion
         *  @return success or error code
         */
        public unsafe
          SVSGigeApiReturn
          Gige_StreamingChannel_getChannelTimeout(int hStreamingChannel,
                                           float* ProgrammedChannelTimeout)
        {
            SVSGigeApiReturn rval;

            rval = StreamingChannel_getChannelTimeout(hStreamingChannel, ProgrammedChannelTimeout);

            return rval;
        }


        /** Set readout transfer.
         *  The readout transfer of a streaming channel will be enabled or disabled
         *  dependent on an isReadoutTransfer parameter. If false, then the camera
         *  would capture an image but it would not transfer the image to the host.
         *  The application can request the streaming channel to send the already
         *  captured data by toggling the isRedoutTransfer parameter to true at
         *  any time after image exposure has finished.
         *  If the isReadoutTransfer parameter is toggled to true before image
         *  exposure has finished then the default behavior will take place where
         *  the camera starts image data transfer immediately after image exposure
         *  has finished.
         *  Controlling readout transfer might be usefull when operating multiple
         *  cameras that are triggered all at the same time. The application will
         *  be able to request data in a pre-defined way on a one-by-one basis and 
         *  to avoid bandwidth bottlenecks this way which otherwise might occur.
         *
         *  @param hStreamingChannel a streaming channel handle received from StreamingChannel_create()
         *  @param isReadoutTransfer whether an image will be transferred to the host after readout
         *  @return success or error code
         */
        public unsafe
          SVSGigeApiReturn
          Gige_StreamingChannel_setReadoutTransfer(int hStreamingChannel,
                                            bool isReadoutTransfer)
        {
            SVSGigeApiReturn rval;

            rval = StreamingChannel_setReadoutTransfer(hStreamingChannel, isReadoutTransfer);

            return rval;
        }


        /** Get readout transfer.
         *  The readout transfer of a streaming channel will be retrieved. If false, 
         *  then the camera would capture an image but it would not transfer the image 
         *  to the host. The application can request the streaming channel to send the 
         *  already captured data by toggling the isRedoutTransfer parameter to true at
         *  any time after image exposure has finished.
         *  If the isReadoutTransfer parameter is toggled to true before image
         *  exposure has finished then the default behavior will take place where
         *  the camera starts image data transfer immediately after image exposure
         *  has finished.
         *  Controlling readout transfer might be usefull when operating multiple
         *  cameras that are triggered all at the same time. The application will
         *  be able to request data in a pre-defined way on a one-by-one basis and 
         *  to avoid bandwidth bottlenecks this way which otherwise might occur.
         *
         *  @param hStreamingChannel a streaming channel handle received from StreamingChannel_create()
         *  @param isReadoutTransfer whether an image will be transferred to the host after readout
         *  @return success or error code
         */
        public unsafe
        SVSGigeApiReturn
        Gige_StreamingChannel_getReadoutTransfer(int hStreamingChannel,
                                          bool* isReadoutTransfer)
        {
            SVSGigeApiReturn rval;

            rval = StreamingChannel_getReadoutTransfer(hStreamingChannel, isReadoutTransfer);

            return rval;
        }



        //------------------------------------------------------------------------------
        // 5 - Stream: Channel statistics
        //------------------------------------------------------------------------------

        /** Get frame loss.
         *  The number of lost frames in a streaming channel will be returned
         *
         *  @param hStreamingChannel a streaming channel handle received from StreamingChannel_create()
         *  @ FrameLoss the number of frames that have been lost since the streaming channel was opened
         *  @return success or error code
         */
        public unsafe
        SVSGigeApiReturn
        Gige_StreamingChannel_getFrameLoss(int hStreamingChannel,
                                    int* FrameLoss)
        {
            SVSGigeApiReturn rval;

            rval = StreamingChannel_getFrameLoss(hStreamingChannel, FrameLoss);

            return rval;
        }



        /** Get actual frame rate.
         *  The actual frame rate calculated from received images will be returned
         *
         *  @param hStreamingChannel a streaming channel handle received from StreamingChannel_create()
         *  @param ActualFrameRate the actual frame rate measured based on received images
         *  @return success or error code
         */

        public unsafe
        SVSGigeApiReturn
        Gige_StreamingChannel_getActualFrameRate(int hStreamingChannel,
                                          float* ActualFrameRate)
        {
            SVSGigeApiReturn rval;

            rval = StreamingChannel_getActualFrameRate(hStreamingChannel, ActualFrameRate);

            return rval;
        }


        /** Get actual data rate.
         *  The actual data rate calculated from received image data will be returned
         *
         *  @param hStreamingChannel a streaming channel handle received from StreamingChannel_create()
         *  @param ActualDataRate the actual frame rate measured based on received image data
         *  @return success or error code
         */

        public unsafe
        SVSGigeApiReturn
        Gige_StreamingChannel_getActualDataRate(int hStreamingChannel,
                                         float* ActualDataRate)
        {
            SVSGigeApiReturn rval;

            rval = StreamingChannel_getActualDataRate(hStreamingChannel, ActualDataRate);

            return rval;
        }


        /** Get peak data rate.
         *  The peak data rate will be returned. It is determined for a single image
         *  transfer by measuring the transfer time from first to last network packet
         *  which belong to a single image. The peak data rate is received by dividing
         *  the amount of data of one image by that transfer time. It can be used for 
         *  evaluating the bandwidth situation when operating multiple GigE cameras 
         *  over a single GigE line.
         *
         *  @param hStreamingChannel a streaming channel handle received from StreamingChannel_create()
         *  @param PeakDataRate the actual frame rate measured based on received image data
         *  @return success or error code
         */

        public unsafe
        SVSGigeApiReturn
        Gige_StreamingChannel_getPeakDataRate(int hStreamingChannel,
                                         float* PeakDataRate)
        {
            SVSGigeApiReturn rval;

            rval = StreamingChannel_getPeakDataRate(hStreamingChannel, PeakDataRate);

            return rval;
        }

        //------------------------------------------------------------------------------
        // 6 - Stream: Channel info 
        //------------------------------------------------------------------------------

        /** Get pixel type.
         *  The pixel type will be returned that applies to the output image (or output
         *  view in case of a MultiStream channel).
           *
         *  @param hStreamingChannel a streaming channel handle received from StreamingChannel_create()
           *  @param ProgrammedPixelType the pixel type that has been set for the output image/view
         *  @return success or error code
         */

        public unsafe
        SVSGigeApiReturn
        Gige_StreamingChannel_getPixelType(int hStreamingChannel,
                                      GVSP_PIXEL_TYPE* ProgrammedPixelType)
        {
            SVSGigeApiReturn rval;

            rval = StreamingChannel_getPixelType(hStreamingChannel, ProgrammedPixelType);

            return rval;
        }

        /** Get buffer data.
         *  A streaming channel will be queried for information about one of its image buffers.
           *  On success, a pointer to image data will be returned.
           *  Since the buffer's data pointer is queried asynchronously with regard to image 
         *  acquisition, no assumption can be made for the content that is in the buffer at 
         *  time of running this function. Image access functions have to be used for obtaining 
         *  actual images that were captured by the camera.
           *
         *  @param hStreamingChannel a streaming channel handle received from StreamingChannel_create()
           *  @param BufferIndex an index of the buffer where information is requested for
           *  @param BufferData a pointer to a data pointer that will return the buffer address
         *  @return success or error code
         */

        public unsafe
         SVSGigeApiReturn
         Gige_StreamingChannel_getBufferData(int hStreamingChannel,
                                     uint BufferIndex,
                                     sbyte** BufferData)
        {
            SVSGigeApiReturn rval;

            rval = StreamingChannel_getBufferData(hStreamingChannel, BufferIndex, BufferData);

            return rval;
        }


        /** Get buffer size.
         *  The buffer size will be returned that applies to the output image (or output
         *  view in case of a MultiStream channel).
           *
         *  @param hStreamingChannel a streaming channel handle received from StreamingChannel_create()
           *  @param BufferSize the buffer size for the output image/view
         *  @return success or error code
         */

        public unsafe
         SVSGigeApiReturn
         Gige_StreamingChannel_getBufferSize(int hStreamingChannel,
                                        int* BufferSize)
        {
            SVSGigeApiReturn rval;

            rval = StreamingChannel_getBufferSize(hStreamingChannel, BufferSize);

            return rval;
        }


        /** Get image pitch.
         *  The image pitch will be returned that applies to the output image (or output
         *  view in case of a MultiStream channel).
           *
         *  @param hStreamingChannel a streaming channel handle received from StreamingChannel_create()
           *  @param ImagePitch the image pitch for the output image/view
         *  @return success or error code
         */

        public unsafe
          SVSGigeApiReturn
          Gige_StreamingChannel_getImagePitch(int hStreamingChannel,
                                         int* ImagePitch)
        {
            SVSGigeApiReturn rval;

            rval = StreamingChannel_getImagePitch(hStreamingChannel, ImagePitch);
            return rval;
        }


        /** Get image size X.
         *  The image size X will be returned that applies to the output image (or output
         *  view in case of a MultiStream channel).
           *
         *  @param hStreamingChannel a streaming channel handle received from StreamingChannel_create()
           *  @param ImageSizeX the image size X for the output image/view
         *  @return success or error code
         */
        public unsafe
         SVSGigeApiReturn
         Gige_StreamingChannel_getImageSizeX(int hStreamingChannel,
                                        int* ImageSizeX)
        {
            SVSGigeApiReturn rval;

            rval = StreamingChannel_getImageSizeX(hStreamingChannel, ImageSizeX);

            return rval;
        }


        /** Get image size Y.
         *  The image size Y will be returned that applies to the output image (or output
         *  view in case of a MultiStream channel).
           *
         *  @param hStreamingChannel a streaming channel handle received from StreamingChannel_create()
           *  @param ImageSizeY the image size Y for the output image/view
         *  @return success or error code
         */
        public unsafe
          SVSGigeApiReturn
          Gige_StreamingChannel_getImageSizeY(int hStreamingChannel,
                                         int* ImageSizeY)
        {
            SVSGigeApiReturn rval;

            rval = StreamingChannel_getImageSizeY(hStreamingChannel, ImageSizeY);

            return rval;
        }


        //------------------------------------------------------------------------------
        // 7 - Stream: Transfer Parameters
        //------------------------------------------------------------------------------

        /** Evaluate maximal packet size.
         *  A test will be performed which determines the maximal usable packet size
         *  based on given network hardware. This value will be used when opening a
         *  streaming channel.
         *
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
           *  @param MaximalPacketSize the maximal possible packet size without fragmentation
         *  @return success or error code
         */
        public unsafe
          SVSGigeApiReturn
          Gige_Camera_evaluateMaximalPacketSize(int hCamera,
                                           ref int MaximalPacketSize)
        {
            SVSGigeApiReturn rval;
            fixed (int* maxPS = &MaximalPacketSize)
            {
                rval = Camera_evaluateMaximalPacketSize(hCamera, maxPS);
            }
            return rval;
        }

        /** Set streaming packet size.
         *  The packet size is set which will be generated by the camera for streaming
         *  image data as payload packets to the host
         *
         *  WARNING! Explicitly setting network packet size to values above 1500 bytes
         *           may provide to unpredictable results and also to a system crash.
         *           Please use "Camera_evaluateMaximalPacketSize" for a save adjustment
         *           to jumbo packets.
       *
       *  @see CameraContainer_getCamera()
       *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param StreamingPacketSize the packet size used by the camera for image packets
       *  @return success or error code
         */
        public unsafe
          SVSGigeApiReturn
          Gige_Camera_setStreamingPacketSize(int hCamera,
                                        int StreamingPacketSize)
        {
            SVSGigeApiReturn rval;

            rval = Camera_setStreamingPacketSize(hCamera, StreamingPacketSize);

            return rval;
        }


        /** Set inter-packet delay
         *  A delay between network packets will be introduced and set to a specified
         *  number of ticks.
         *
         *  NOTE: The resulting total image transfer time must not exceed 250 ms.
         *  Otherwise a timeout condition will be reached in the SVGigE driver.
         *  The dependency between inter-packet delay and total image transfer time
         *  depends on pixel clock, image size and has to be determine case by case.
         *
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param InterPackedDelay the new value for inter-packet delay (0..1000, relative number)
         *  @return success or error code
         */

        public unsafe
          SVSGigeApiReturn
          Gige_Camera_setInterPacketDelay(int hCamera,
                                     float InterPacketDelay)
        {
            SVSGigeApiReturn rval;

            rval = Camera_setInterPacketDelay(hCamera, InterPacketDelay);

            return rval;
        }


        /** Get inter-packet delay
         *  The delay between network packets will be returned as a relative number
         *  of ticks.
         *
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param InterPackedDelay the currently programmed value for inter-packet delay (0..1000, relative number)
         *  @return success or error code
         */

        public unsafe
          SVSGigeApiReturn
          Gige_Camera_getInterPacketDelay(int hCamera,
                                     float* ProgrammedInterPacketDelay)
        {
            SVSGigeApiReturn rval;

            rval = Camera_getInterPacketDelay(hCamera, ProgrammedInterPacketDelay);

            return rval;
        }


        /** Set multicast mode
         *  The multicast mode will be set to none (default), listener or controller.
         *
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
           *  @param MulticastMode the intended new multicast mode
         *  @return success or error code
         */

        public unsafe
          SVSGigeApiReturn
          Gige_Camera_setMulticastMode(int hCamera,
                                  MULTICAST_MODE MulticastMode)
        {
            SVSGigeApiReturn rval;

            rval = Camera_setMulticastMode(hCamera, MulticastMode);

            return rval;
        }


        /** Get multicast mode
         *  Current multicast mode will be retrieved from the camera.
         *
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
           *  @param MulticastMode current multicast mode will be returned
         *  @return success or error code
         */

        public unsafe
          SVSGigeApiReturn
          Gige_Camera_getMulticastMode(int hCamera,
                                  MULTICAST_MODE* MulticastMode)
        {
            SVSGigeApiReturn rval;

            rval = Camera_getMulticastMode(hCamera, MulticastMode);

            return rval;
        }


        /** Get multicast group
         *  Current multicast group (IP) and port will be retrieved from the camera.
         *
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
           *  @param MulticastGroup current multicast group (IP) will be returned
           *  @param MulticastPort current multicast port will be returned
         *  @return success or error code
         */

        public unsafe
          SVSGigeApiReturn
          Gige_Camera_getMulticastGroup(int hCamera,
                                   uint* MulticastGroup,
                                   uint* MulticastPort)
        {
            SVSGigeApiReturn rval;

            rval = Camera_getMulticastGroup(hCamera, MulticastGroup, MulticastPort);


            return rval;
        }


        //------------------------------------------------------------------------------
        // Image
        //------------------------------------------------------------------------------

        /**
             * Release image.
             * An image which availability was indicated by a StreamCallback function needs
             * to be released after processing it by a user application in order to free
             * the occupied buffer space for a subsequent image acquisition.
             *
             * After releasing a picture the following access functions must not be
             * called anymore using the released image handle
             *
             * @param hStreamingChannel a streaming channel handle received from StreamingChannel_create()
             * @param Image an image handle that was received from the callback function
             * @return success or error code
             */
        public unsafe
            SVSGigeApiReturn
            Gige_Image_release(int hImage)
        {
            return Image_release(hImage);
        }


        /**
             * Get image pointer.
             * A pointer to the image data will be returned
             *
             * @param hStreamingChannel a streaming channel handle received from StreamingChannel_create()
             * @param Image an image handle that was received from the callback function
             * @return a pointer to the image data
             */
        public unsafe
            IntPtr
            Gige_Image_getDataPointer(int hImage)
        {
            IntPtr iptr;
            sbyte* image;
            image = Image_getDataPointer(hImage);
            iptr = (IntPtr)image;
            return iptr;
        }

        /** Get buffer index.
         *  The index of the current image buffer will be returned
         *
         *  @param Image an image handle that was received from the callback function
         *  @return a pointer to the image data
         */
        public unsafe
         int Gige_Image_getBufferIndex(int hImage)
        {
            return Image_getBufferIndex(hImage);
        }

        /** Get signal type
         *  The signal type that is related to a callback will be returned
         *
         *  @param Image an image handle that was received from the callback function
         *  @return the signal type which informs why a callback was triggered
         */

        public unsafe
         SVGigE_SIGNAL_TYPE Gige_Image_getSignalType(int hImage)
        {
            return Image_getSignalType(hImage);
        }

        /** Get camera handle
         *  A handle of the camera that captured the image will be returned
         *
         *  @param Image an image handle that was received from the callback function
         *  @return a camera handle
         */

        public unsafe
        int Gige_Image_getCamera(int hImage)
        {
            return Image_getCamera(hImage);
        }
        //------------------------------------------------------------------------------
        // 7 - Stream: Image conversion
        //------------------------------------------------------------------------------

        // Convert image to RGB-image
        /** Get image RGB
          *
          *  The image will be converted by a selectable Bayer conversion algorithm into
          *  a RGB image. The caller needs to provide a sufficient buffer.
          *
          *  @param Image an image handle that was received from the callback function
          *  @param BufferRGB a buffer for RGB image data
          *  @param BufferLength the length of the image buffer
          *  @param BayerMethod the a demosaicking method (Bayer method)
          *  @return success or error code
          */

        public unsafe
            SVSGigeApiReturn
            Gige_Image_getImageRGB(int hImage, byte* bufferRGB,               // IntPtr bufferRGB,
                            int BufferLength, BAYER_METHOD BayerMethod)
        {

            SVSGigeApiReturn rval = SVSGigeApiReturn.SVGigE_ERROR;

            rval = Image_getImageRGB(hImage, bufferRGB, BufferLength, BayerMethod);

            return rval;

        }

        /** Get image gray
         *
         *  A bayer coded image will be converted into a BW image. The caller needs to
         *  provide a sufficient 8-bit buffer.
         *
         *  @param Image an image handle that was received from the callback function
         *  @param Buffer8bit a buffer for 8-bit image data
         *  @param BufferLength the length of the image buffer
         *  @return success or error code
         */
        public unsafe
            SVSGigeApiReturn
          Gige_Image_getImageGray(int hImage,
                            byte* Buffer8bit,
                            int BufferLength)
        {

            SVSGigeApiReturn rval = SVSGigeApiReturn.SVGigE_ERROR;

            rval = Image_getImageGray(hImage, Buffer8bit, BufferLength);

            return rval;

        }

        /** Get image 12-bit as 8-bit
         *  A 12-bit image will be converted into a 8-bit image. The caller needs to
         *  provide for a sufficient buffer for the 8-bit image.
       *
       *  @param Image an image handle that was received from the callback function
       *  @param Buffer8bit a buffer for 8-bit image data
       *  @param BufferLength the length of the image buffer
       *  @return success or error code
         */


        public unsafe
            SVSGigeApiReturn
            Gige_Image_getImage12bitAs8bit(int hImage,
                                    byte* Buffer8bit,
                                    int BufferLength)
        {

            SVSGigeApiReturn rval = SVSGigeApiReturn.SVGigE_ERROR;

            rval = Image_getImage12bitAs8bit(hImage, Buffer8bit, BufferLength);

            return rval;

        }


        /** Get image 12-bit as 16-bit
         *  A 12-bit image will be converted into a 16-bit image. The caller needs to
         *  provide for a sufficiently large buffer (2 x width x height bytes) for the
       *  16-bit image.
       *
       *  @param Image an image handle that was received from the callback function
       *  @param Buffer16bit a buffer for 16-bit image data
       *  @param BufferLength the length of the image buffer
       *  @return success or error code
         */


        public unsafe
            SVSGigeApiReturn
            Gige_Image_getImage12bitAs16bit(int hImage,
                                     byte* Buffer16bit,
                                     int BufferLength)
        {

            SVSGigeApiReturn rval = SVSGigeApiReturn.SVGigE_ERROR;

            rval = Image_getImage12bitAs16bit(hImage, Buffer16bit, BufferLength);

            return rval;

        }

        /** Get image 16-bit as 8-bit
         *  A 16-bit image will be converted into a 8-bit image. The caller needs to
         *  provide for a sufficient buffer for the 8-bit image.
       *
       *  @param Image an image handle that was received from the callback function
       *  @param Buffer8bit a buffer for 8-bit image data
       *  @param BufferLength the length of the image buffer
       *  @return success or error code
         */


        public unsafe
            SVSGigeApiReturn
            Gige_Image_getImage16bitAs8bit(int hImage,
                                    byte* Buffer8bit,
                                    int BufferLength)
        {

            SVSGigeApiReturn rval = SVSGigeApiReturn.SVGigE_ERROR;

            rval = Image_getImage16bitAs8bit(hImage, Buffer8bit, BufferLength);

            return rval;

        }


        //------------------------------------------------------------------------------
        // 8 - Stream: Image characteristics
        //------------------------------------------------------------------------------

        /**
             * Get image size X
             * The horizontal pixel number will be returned as received from the camera
             *
             * @param hStreamingChannel a streaming channel handle received from StreamingChannel_create()
             * @param Image an image handle that was received from the callback function
             * @return the image's size X as received from the camera
             */
        public unsafe
            int
            Gige_Image_getSizeX(int hImage)
        {
            return Image_getSizeX(hImage);
        }

        /**
             * Get image size Y
             * The vertical pixel number will be returned as received from the camera
             *
             * @param hStreamingChannel a streaming channel handle received from StreamingChannel_create()
             * @param Image an image handle that was received from the callback function
             * @return the image's size Y as received from the camera
             */
        public unsafe
            int
            Gige_Image_getSizeY(int hImage)
        {
            return Image_getSizeY(hImage);

        }

        /**
         * Get image pitch
         * The number of bytes in a row (pitch) will be returned as received from the camera
         *
         * @param hStreamingChannel a streaming channel handle received from StreamingChannel_create()
         * @param Image an image handle that was received from the callback function
         * @return the image's pitch as received from the camera
         */
        public unsafe
            int
            Gige_Image_getPitch(int hImage)
        {
            return Image_getPitch(hImage);
        }

        /**
             * Get image size.
             * The number of bytes in the image data field will be returned.
             *
             * @param hStreamingChannel a streaming channel handle received from StreamingChannel_create()
             * @param Image an image handle that was received from the callback function
             * @return the number of bytes in the image data field
             */
        public unsafe
            int
            Gige_Image_getImageSize(int hImage)
        {
            return Image_getImageSize(hImage);
        }


        /**
             * Get pixel type
             * The pixel type as indicated by the camera will be returned
             *
             * @param hStreamingChannel a streaming channel handle received from StreamingChannel_create()
             * @param Image an image handle that was received from the callback function
             * @return the pixel type as indicated by the camera
             */
        public unsafe
            GVSP_PIXEL_TYPE
            Gige_Image_getPixelType(int hImage)
        {
            GVSP_PIXEL_TYPE type = GVSP_PIXEL_TYPE.GVSP_PIX_UNKNOWN;

            type = Image_getPixelType(hImage);

            return type;

        }


        //------------------------------------------------------------------------------
        // 9 - Stream: Image statistics
        //------------------------------------------------------------------------------


        /**
         * Get image identifier.
         *
         * An image identifier will be returned as it was assigned by the camera.
         * Usually the camera will assign an increasing sequence of integer numbers
         * to subsequent images which will wrap at some point and jump back to 1.
         * The 0 identifier will not be used as it is defined in the GigE Vision
         * specification
         *
         * @param hStreamingChannel a streaming channel handle received from StreamingChannel_create()
         * @param Image an image handle that was received from the callback function
         * @return an integer number that is unique inside a certain sequence of numbers
         */
        public unsafe
            int
            Gige_Image_getImageID(int hImage)
        {
            return Image_getImageID(hImage);
        }

        /**
             * Get image timestamp
             * The timestamp that was assigned to an image by the camera on image
             * acquisition will be returned
             *
             * @param hStreamingChannel a streaming channel handle received from StreamingChannel_create()
             * @param Image an image handle that was received from the callback function
             * @return a timestamp as it was received from the camera in seconds after
             *   January, 1st 1970 where the fraction represents parts of a second
             */
        public unsafe
            double
            Gige_Image_getTimestamp(int hImage)
        {
            return Image_getTimestamp(hImage);
        }


        /** Get image transfer time
         *  The time that elapsed from image's first network packet arriving on PC side
         *  until image completion will be determined, including possible packet resends.
         *
         *  @param Image an image handle that was received from the callback function
         *  @return image's transfer time as it was explained above
         */

        public unsafe
        double Gige_Image_getTransferTime(int hImage)
        {
            return Image_getTransferTime(hImage);
        }


        /** Get packet count
         *  The number of packets that belong to a frame will be returned
         *
         *  @param Image an image handle that was received from the callback function
         *  @return the pixel type as indicated by the camera
         */

        public unsafe
        int Gige_Image_getPacketCount(int hImage)
        {
            return Image_getPacketCount(hImage);
        }


        /** Get packet resend
         *  The number of packets that have been resent will be reported
         *
         *  @param Image an image handle that was received from the callback function
         *  @return the pixel type as indicated by the camera
         */

        public unsafe
        int Gige_Image_getPacketResend(int hImage)
        {
            return Image_getPacketResend(hImage);
        }

        //------------------------------------------------------------------------------
        // 10 - Stream: Messaging channel
        //------------------------------------------------------------------------------

        /** Create event.
         *  An event will be created inside GigE API which is capable of waiting for
         *  messages that are issued inside a streaming channel. One or more message
         *  types have to be added to the event before messages will be actually
         *  delivered to the application.
         *
         *  @see CameraContainer_getCamera()
         *  @param hStreamingChannel a handle to a valid streaming channel
         *  @param EventID a pointer to the identifier of a messaging channel
         *  @param SizeFIFO the number of entries in a message FIFO (0 = no FIFO)
         *  @return success or error code
         */

        public unsafe
        SVSGigeApiReturn
        Gige_Stream_createEvent(int hStreamingChannel, int* EventID, int SizeFIFO)
        {
            SVSGigeApiReturn rval;

            rval = Stream_createEvent(hStreamingChannel, EventID, SizeFIFO);

            return rval;
        }



        /** Add message type.
         *  A message type will be added to a previously created messaging channel.
         *
         *  @see CameraContainer_getCamera()
         *  @param hStreamingChannel a handle to a valid streaming channel
         *  @param EventID the identifier of a messaging channel
         *  @param MessageType one of pre-defined message types
         *  @return success or error code
         */

        public unsafe
         SVSGigeApiReturn
         Gige_Stream_addMessageType(int hStreamingChannel, int EventID,
           SVGigE_SIGNAL_TYPE MessageType)
        {
            SVSGigeApiReturn rval;

            rval = Stream_addMessageType(hStreamingChannel, EventID, MessageType);

            return rval;
        }


        /** Remove message type.
         *  A message type will be removed from a previously created messaging channel.
         *
         *  @see CameraContainer_getCamera()
         *  @param hStreamingChannel a handle to a valid streaming channel
         *  @param EventID the identifier of a messaging channel
         *  @param MessageType one of pre-defined message types
         *  @return success or error code
         */

        public unsafe
         SVSGigeApiReturn
         Gige_Stream_removeMessageType(int hStreamingChannel,
          int EventID,
          SVGigE_SIGNAL_TYPE MessageType)
        {
            SVSGigeApiReturn rval;

            rval = Stream_removeMessageType(hStreamingChannel, EventID, MessageType);
            return rval;
        }


        /** Is message pending.
         *  A messaging channel with a given EventID will be checked whether pending
         *  messages are available. The function will return a result immediately if
         *  the timeout is set to zero. Otherwise it will wait for a message atmost
         *  till the timeout elapses.
         *
         *  @see CameraContainer_getCamera()
         *  @param hStreamingChannel a handle to a valid streaming channel
         *  @param EventID the identifier of a messaging channel
         *  @param Timeout_ms a timeout value in milliseconds
         *  @return success or error code
         */

        public unsafe
            SVSGigeApiReturn
            Gige_Stream_isMessagePending(int hStreamingChannel, int EventID, int Timeout_ms)
        {
            SVSGigeApiReturn rval;

            rval = Stream_isMessagePending(hStreamingChannel, EventID, Timeout_ms);

            return rval;
        }


        /** Register event callback.
         *  A callback function will be registered which will be called whenever an event is
         *  signalled in the messaging channel. One parameter of the callback is a Context
         *  which was registered along with the callback.
         *
         *  @see CameraContainer_getCamera()
         *  @param hStreamingChannel a handle to a valid streaming channel
         *  @param EventID the identifier of a messaging channel
         *  @param Callback the pointer of an EventCallback function
         *  @param Context an arbitrary value that will be returned with each call to EventCallback
         *  @return success or error code
         */

        public unsafe
            SVSGigeApiReturn
            Gige_Stream_registerEventCallback(ref int hStreamingChannel,
                         int EventID,
                         EventCallback Callback,
                         int Context)
        {
            SVSGigeApiReturn rval;
            int ct = 0x7000000;
            fixed (int* hSC = &hStreamingChannel)
            {
                rval = Stream_registerEventCallback(hStreamingChannel, EventID, Callback, (void*)ct);
            }
            return rval;
        }


    /** Unregister event callback.
     *  A previously registered callback function will be unregistered from message channel.
     *  This will effectively stop any further calls to that function.
     *
     *  @see CameraContainer_getCamera()
     *  @param hStreamingChannel a handle to a valid streaming channel
     *  @param EventID the identifier of a messaging channel
     *  @param Callback the pointer of an EventCallback function
     *  @return success or error code
     */

    public unsafe
            SVSGigeApiReturn
            Gige_Stream_unregisterEventCallback(int hStreamingChannel,
                           int EventID,
                           EventCallback Callback)
        {
            SVSGigeApiReturn rval;

            rval = Stream_unregisterEventCallback(hStreamingChannel, EventID, Callback);

            return rval;
        }


        /** Get message.
         *  A subsequent MessageID will be retrieved for a previously received EventID.
         *
         *  @see CameraContainer_getCamera()
         *  @param hStreamingChannel a handle to a valid streaming channel
         *  @param EventID an ID of a messaging channel from EventCallback() or from isMessagePending()
         *  @param MessageID a pointer to a MessageID variable
         *  @param MessageType a pointer to a MessageType variable
         *  @return success or error code
         */

        public unsafe
            SVSGigeApiReturn
            Gige_Stream_getMessage(int hStreamingChannel, int EventID, int* MessageID,
              SVGigE_SIGNAL_TYPE* MessageType)
        {
            SVSGigeApiReturn rval;

            rval = Stream_getMessage(hStreamingChannel, EventID, MessageID, MessageType);

            return rval;
        }


        /** Get message data.
         *  The data pointer and length will be retrieved for a previously received MessageID.
         *
         *  @see CameraContainer_getCamera()
         *  @param hStreamingChannel a handle to a valid streaming channel
         *  @param EventID the identifier of a messaging channel
         *  @param MessageID a message identifier received from getMessage()
         *  @param MessageData a pointer to a void* variable
         *  @param MessageLength a pointer to a data length variable
         *  @return success or error code
         */

        public unsafe
            SVSGigeApiReturn
            Gige_Stream_getMessageData(int hStreamingChannel, int EventID, int MessageID,
                  void** MessageData, int* MessageLength)
        {
            SVSGigeApiReturn rval;

            rval = Stream_getMessageData(hStreamingChannel, EventID, MessageID, MessageData, MessageLength);

            return rval;
        }


        /** Get message Timestamp.
         *  A message's timestamp will be retrieved for a previously received MessageID.
         *
         *  @see CameraContainer_getCamera()
         *  @param hStreamingChannel a handle to a valid streaming channel
         *  @param EventID the identifier of a messaging channel
         *  @param MessageID a message identifier received from getMessage()
         *  @param MessageTimestamp a pointer to a Timestamp variable
         *  @return success or error code
         */

        public unsafe
            SVSGigeApiReturn
            Gige_Stream_getMessageTimestamp(int hStreamingChannel,
                       int EventID,
                       int MessageID,
                       double* MessageTimestamp)
        {
            SVSGigeApiReturn rval;

            rval = Stream_getMessageTimestamp(hStreamingChannel, EventID, MessageID, MessageTimestamp);

            return rval;
        }


        /** Release message.
         *  A previously received MessageID will be released. No further access must happen
         *  for the released MessageID since it will be removed from memory.
         *
         *  @see CameraContainer_getCamera()
         *  @param hStreamingChannel a handle to a valid streaming channel
         *  @param EventID the identifier of a messaging channel
         *  @param MessageID a message identifier received from getMessage()
         *  @return success or error code
         */

        public unsafe
            SVSGigeApiReturn
            Gige_Stream_releaseMessage(int hStreamingChannel,
                  int EventID,
                  int MessageID)
        {
            SVSGigeApiReturn rval;

            rval = Stream_releaseMessage(hStreamingChannel, EventID, MessageID);

            return rval;
        }


        /** Flush messages.
         *  All messages in the message FIFO will be removed.
         *
         *  @see CameraContainer_getCamera()
         *  @param hStreamingChannel a handle to a valid streaming channel
         *  @param EventID the identifier of a messaging channel
         *  @return success or error code
         */

        public unsafe
            SVSGigeApiReturn
            Gige_Stream_flushMessages(int hStreamingChannel, int EventID)
        {
            SVSGigeApiReturn rval;

            rval = Stream_flushMessages(hStreamingChannel, EventID);

            return rval;
        }


        /** Close event.
         *  The messaging channel with given EventID will be closed and all resources
         *  will be freed.
         *
         *  @see CameraContainer_getCamera()
         *  @param hStreamingChannel a handle to a valid streaming channel
         *  @param EventID the identifier of a messaging channel
         *  @return success or error code
         */

        public unsafe
            SVSGigeApiReturn
            Gige_Stream_closeEvent(int hStreamingChannel, int EventID)
        {
            SVSGigeApiReturn rval;

            rval = Stream_closeEvent(hStreamingChannel, EventID);

            return rval;
        }

        //------------------------------------------------------------------------------
        // 11 - Controlling camera: Frame rate
        //------------------------------------------------------------------------------

        /**
         * Set framerate.
         * The camera will be adjusted to a new framerate
         *
         * @see CameraContainer_getCamera()
         * @param hCamera a camera handle received from CameraContainer_getCamera()
         * @param Framerate new framerate in 1/s
         * @return success or error code
         */
        public unsafe
            SVSGigeApiReturn
            Gige_Camera_setFrameRate(int hCamera,
            float Framerate)
        {
            return Camera_setFrameRate(hCamera, Framerate);
        }

        /**
         * Get framerate.
         * The currently programmed framerate will be retrieved
         *
         * @see CameraContainer_getCamera()
         * @param hCamera a camera handle received from CameraContainer_getCamera()
         * @param ProgrammedFramerate currently programmed framerate in 1/s
         * @return success or error code
         */
        public unsafe
            SVSGigeApiReturn
            Gige_Camera_getFrameRate(int hCamera,
            ref float Framerate)
        {
            fixed (float* ProgrammedFramerate = &Framerate)
            {
                return Camera_getFrameRate(hCamera, ProgrammedFramerate);
            }
        }

        /**
         * Get framerate min.
         *  The minimal available framerate will be returned
         *
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param MinFramerate the minimal framerate in 1/s
         *  @return success or error code
         */
        public unsafe
            SVSGigeApiReturn
            Gige_Camera_getFrameRateMin(int hCamera, float* MinFramerate)
        {
            return Camera_getFrameRateMin(hCamera, MinFramerate);
        }



        /** Get framerate max.
         *  The maximal available framerate will be returned
         *
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param MaxFramerate the maximal framerate in 1/s
         *  @return success or error code
         */
        public unsafe
            SVSGigeApiReturn
            Gige_Camera_getFrameRateMax(int hCamera, float* MaxFramerate)
        {
            return Camera_getFrameRateMax(hCamera, MaxFramerate);
        }


        /** Get framerate range.
         *  The currently available framerate range will be retrieved
         *
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param MinFramerate currently available minimal framerate in 1/s
         *  @param MaxFramerate currently available maximal framerate in 1/s
         *  @return success or error code
         */
        public unsafe
            SVSGigeApiReturn
          Gige_Camera_getFrameRateRange(int hCamera, float* MinFramerate, float* MaxFramerate)
        {
            return Camera_getFrameRateRange(hCamera, MinFramerate, MaxFramerate);
        }


        /** Get framerate increment.
         *  The framerate increment will be returned
         *
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param FramerateIncrement the framerate increment in 1/s
         *  @return success or error code
         */

        public unsafe
            SVSGigeApiReturn
          Gige_Camera_getFrameRateIncrement(int hCamera, float* FramerateIncrement)
        {
            return Camera_getFrameRateIncrement(hCamera, FramerateIncrement);
        }

        //------------------------------------------------------------------------------
        // 12 - Controlling camera: Exposure
        //------------------------------------------------------------------------------

        /**
         * Set exposure time.
         * The camera will be adjusted to a new exposure time
         *
         * @see CameraContainer_getCamera()
         * @param hCamera a camera handle received from CameraContainer_getCamera()
         * @param ExposureTime new exposure time in s
         * @return success or error code
         */
        public unsafe
            SVSGigeApiReturn
            Gige_Camera_setExposureTime(int hCamera,
            float ExposureTime)
        {
            return Camera_setExposureTime(hCamera, ExposureTime);
        }

        /**
         * Get exposure time.
         * The currently programmed exposure time will be retrieved
         *         
         * @see CameraContainer_getCamera()
         * @param hCamera a camera handle received from CameraContainer_getCamera()
         * @param ProgrammedExposureTime currently programmed exposure time in s
         * @return success or error code
         */
        public unsafe
            SVSGigeApiReturn
            Gige_Camera_getExposureTime(int hCamera,
            ref float ExposureTime)
        {
            fixed (float* ProgrammedExposureTime = &ExposureTime)
            {
                return Camera_getExposureTime(hCamera, ProgrammedExposureTime);
            }
        }


        /** Get exposure time min.
         *  The minimal setting for exposure time will be returned.
         *
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param MinExposureTime the minimal exposure time setting in microseconds
         *  @return success or error code
         */

        public unsafe
            SVSGigeApiReturn
          Gige_Camera_getExposureTimeMin(int hCamera, float* MinExposureTime)
        {
            return Camera_getExposureTimeMin(hCamera, MinExposureTime);
        }



        /** Get exposure time max.
         *  The maximal setting for exposure will be returned.
         *
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param MaxExposureTime the maximal exposure time setting in microseconds
         *  @return success or error code
         */

        public unsafe
            SVSGigeApiReturn
          Gige_Camera_getExposureTimeMax(int hCamera, float* MaxExposureTime)
        {
            return Camera_getExposureTimeMax(hCamera, MaxExposureTime);
        }



        /** Get exposure time range.
         *  The currently available exposure time range will be retrieved.
         *  NOTE: The received values will apply to free-running mode. In triggered mode the
         *        usual exposure time is limited to slightly more than 1 second. Exposure
         *        times above 1 second require changes in internal camera settings. Please
         *        contact SVS VISTEK if the camera needs to run in that exposure time range.
         *
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param MinExposureTime currently available minimal exposure time in microseconds
         *  @param MaxExposureTime currently available maximal exposure time in microseconds
         *  @return success or error code
         */

        public unsafe
            SVSGigeApiReturn
          Gige_Camera_getExposureTimeRange(int hCamera,
                                      float* MinExposureTime,
                                      float* MaxExposureTime)
        {
            return Camera_getExposureTimeRange(hCamera, MinExposureTime, MaxExposureTime);
        }


        /** Get exposure time increment.
         *  The increment for exposure time will be returned.
         *
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param ExposureTimeIncrement the exposure time increment in microseconds
         *  @return success or error code
         */

        public unsafe
            SVSGigeApiReturn
          Gige_Camera_getExposureTimeIncrement(int hCamera, float* ExposureTimeIncrement)
        {
            return Camera_getExposureTimeIncrement(hCamera, ExposureTimeIncrement);
        }




        /**
         * Set exposure delay
         * The camera's exposure delay in micro seconds relative to the trigger
         * pulse will be set to the provided value. The delay will become active
         * each time an active edge of an internal or external trigger pulse arrives
         *
         * @see CameraContainer_getCamera()
         * @param hCamera a camera handle received from CameraContainer_getCamera()
         * @param ExposureDelay the new value for exposure delay
         * @return success or error code
         */
        public unsafe
            SVSGigeApiReturn
            Gige_Camera_setExposureDelay(int hCamera,
            float ExposureDelay)
        {
            return Camera_setExposureDelay(hCamera, ExposureDelay);
        }

        /**
         * Get exposure delay
         * The camera's current exposure delay will be returned in micro seconds
         * relative to the trigger pulse
         *
         * @see CameraContainer_getCamera()
         * @param hCamera a camera handle received from CameraContainer_getCamera()
         * @param ExposureDelay the currently programmed value for exposure delay
         * @return success or error code
         */
        public unsafe
            SVSGigeApiReturn
            Gige_Camera_getExposureDelay(int hCamera,
            float* ProgrammedExposureDelay)
        {
            return Camera_getExposureDelay(hCamera, ProgrammedExposureDelay);
        }


        /** Get maximal exposure delay.
         *  The camera's maximal exposure delay will be returned in micro seconds
         *
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param MaxExposureDelay the maximal value for exposure delay in microseconds
         *  @return success or error code
         */
        public unsafe
          SVSGigeApiReturn
          Gige_Camera_getExposureDelayMax(int hCamera,
                                     float* MaxExposureDelay)
        {
            return Camera_getExposureDelayMax(hCamera, MaxExposureDelay);
        }


        /** Get exposure delay increment.
         *  The camera's exposure delay increment will be returned in micro seconds
         *
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param ExposureDelayIncrement the exposure delay increment in microseconds
         *  @return success or error code
         */
        public unsafe
          SVSGigeApiReturn
          Gige_Camera_getExposureDelayIncrement(int hCamera,
                                           float* ExposureDelayIncrement)
        {
            return Camera_getExposureDelayIncrement(hCamera, ExposureDelayIncrement);
        }


        //------------------------------------------------------------------------------
        // 13 - Controlling camera: Gain and offset
        //------------------------------------------------------------------------------

        /**
         * Set gain.
         * The camera will be adjusted to a new analog gain
         *
         * @see CameraContainer_getCamera()
         * @param hCamera a camera handle received from CameraContainer_getCamera()
         * @param Gain currently programmed analog gain
         * @return success or error code
         */
        public unsafe
        SVSGigeApiReturn
        Gige_Camera_setGain(int hCamera,
        float Gain)
        {
            return Camera_setGain(hCamera, Gain);
        }

        /**
         * Get gain.
         * The currently programmed analog gain will be retrieved
         * Note: A gain of 1.0 is represented as integer 128 in the appropriate camera
         * register. Thus the gain can be adjusted only in discrete steps.
         *
         * @see CameraContainer_getCamera()
         * @param hCamera a camera handle received from CameraContainer_getCamera()
         * @param ProgrammedGain currently programmed analog gain
         * @return success or error code
         */
        public unsafe
        SVSGigeApiReturn
        Gige_Camera_getGain(int hCamera,
        float* ProgrammedGain)
        {
            return Camera_getGain(hCamera, ProgrammedGain);
        }

        /** Get maximal gain.
         *  The maximal analog gain will be returned.
         *
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param MaxGain the maximal analog gain
         *  @return success or error code
         */
        public unsafe
            SVSGigeApiReturn
             Gige_Camera_getGainMax(int hCamera, float* MaxGain)
        {
            return Camera_getGainMax(hCamera, MaxGain);
        }


        /** Get maximal extended gain.
         *  The maximal extended analog gain will be returned. An extended gain
         *  allows for operating a camera outside specified range. Noise and
         *  distortions will increase above those values that are met inside
         *  specified range.
         *
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param MaxGain the maximal analog gain
         *  @return success or error code
         */
        public unsafe
            SVSGigeApiReturn
              Gige_Camera_getGainMaxExtended(int hCamera, float* MaxGainExtended)
        {
            return Camera_getGainMaxExtended(hCamera, MaxGainExtended);
        }



        /** Get gain increment.
         *  The analog gain increment will be returned.
         *
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param GainIncrement the analog gain increment
         *  @return success or error code
         */
        public unsafe
            SVSGigeApiReturn
              Gige_Camera_getGainIncrement(int hCamera, float* GainIncrement)
        {
            return Camera_getGainIncrement(hCamera, GainIncrement);
        }


        /**
         * Set offset
         * The ofset value will be set to the provided value
         *
         * @see CameraContainer_getCamera()
         * @param hCamera a camera handle received from CameraContainer_getCamera()
         * @param Offset the new value for offset
         * @return success or error code
         */
        public unsafe
            SVSGigeApiReturn
            Gige_Camera_setOffset(int hCamera,
            float Offset)
        {
            return Camera_setOffset(hCamera, Offset);
        }

        /**
         * Get offset
         * The current offset value will be returned
         *
         * @see CameraContainer_getCamera()
         * @param hCamera a camera handle received from CameraContainer_getCamera()
         * @param Offset the currently programmed value for offset
         * @return success or error code
         */
        public unsafe
            SVSGigeApiReturn
            Gige_Camera_getOffset(int hCamera,
            float* ProgrammedOffset)
        {
            return Camera_getOffset(hCamera, ProgrammedOffset);
        }


        /** Get maximal offset
         *  The maximal offset value will be returned
         *
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param MaxOffset the maximal value for pixel offset
         *  @return success or error code
         */

        public unsafe
        SVSGigeApiReturn
          Gige_Camera_getOffsetMax(int hCamera, float* MaxOffset)
        {
            return Camera_getOffsetMax(hCamera, MaxOffset);
        }



        //------------------------------------------------------------------------------
        // 14 - Controlling camera: Auto gain / exposure
        //------------------------------------------------------------------------------

        /** Set auto gain enabled
         *  The auto gain status will be switched on or off.
         *
         *  @param Camera a handle from a camera that has been opened before
         *  @param isAutoGainEnabled whether auto gain has to be enabled or disabled
         *  @return SVGigE_SUCCESS or an appropriate SVGigE error code
         */

        public unsafe
        SVSGigeApiReturn
        Gige_Camera_setAutoGainEnabled(int Camera, bool isAutoGainEnabled)
        {
            return Camera_setAutoGainEnabled(Camera, isAutoGainEnabled);
        }


        /** Get auto gain enabled
         *  Current auto gain status will be returned.
         *
         *  @param Camera a handle from a camera that has been opened before
         *  @param isAutoGainEnabled whether auto gain is enabled or disabled
         *  @return SVGigE_SUCCESS or an appropriate SVGigE error code
         */

        public unsafe
        SVSGigeApiReturn
        Gige_Camera_getAutoGainEnabled(int Camera, bool* isAutoGainEnabled)
        {
            return Camera_getAutoGainEnabled(Camera, isAutoGainEnabled);
        }


        /** Set auto gain brightness
         *  The target brightness (0..255) will be set which the camera tries to
         *  reach automatically when auto gain/exposure is enabled. The range
         *  0..255 always applies independently from pixel depth.
         *
         *  @param Camera a handle from a camera that has been opened before
         *  @param Brightness the target brightness for auto gain enabled
         *  @return SVGigE_SUCCESS or an appropriate SVGigE error code
         */

        public unsafe
        SVSGigeApiReturn
        Gige_Camera_setAutoGainBrightness(int Camera, float Brightness)
        {
            return Camera_setAutoGainBrightness(Camera, Brightness);
        }

        /** Get auto gain brightness
         *  The target brightness (0..255) will be returned that the camera tries
         *  to reach automatically when auto gain/exposure is enabled.
         *
         *  @param Camera a handle from a camera that has been opened before
         *  @param ProgrammedBrightness a pointer to a target brightness value
         *  @return SVGigE_SUCCESS or an appropriate SVGigE error code
         */

        public unsafe
        SVSGigeApiReturn
        Gige_Camera_getAutoGainBrightness(int Camera, float* ProgrammedBrightness)
        {
            return Camera_getAutoGainBrightness(Camera, ProgrammedBrightness);
        }

        /** Set auto gain dynamics
         *  AutoGain PID regulator's time constants for the I (integration) and
         *  D (differentiation) components will be set to new values.
         *
         *  @param Camera a handle from a camera that has been opened before
         *  @param AutoGainParameterI the I parameter in a PID regulation loop
         *  @param AutoGainParameterD the D parameter in a PID regulation loop
         *  @return SVGigE_SUCCESS or an appropriate SVGigE error code
         */

        public unsafe
        SVSGigeApiReturn
        Gige_Camera_setAutoGainDynamics(int Camera,
                                 float AutoGainParameterI,
                                 float AutoGainParameterD)
        {
            return Camera_setAutoGainDynamics(Camera, AutoGainParameterI, AutoGainParameterD);
        }

        /** Get auto gain dynamics
         *  AutoGain PID regulator's time constants for the I (integration) and
         *  D (differentiation) components will be retrieved from the camera.
         *
         *  @param Camera a handle from a camera that has been opened before
         *  @param ProgrammedAutoGainParameterI the I parameter in a PID regulation loop
         *  @param ProgrammedAutoGainParameterD the D parameter in a PID regulation loop
         *  @return SVGigE_SUCCESS or an appropriate SVGigE error code
         */

        public unsafe
        SVSGigeApiReturn
        Gige_Camera_getAutoGainDynamics(int Camera,
                                 float* ProgrammedAutoGainParameterI,
                                 float* ProgrammedAutoGainParameterD)
        {
            return Camera_getAutoGainDynamics(Camera, ProgrammedAutoGainParameterI, ProgrammedAutoGainParameterD);
        }


        /** Set auto gain limits
         *  The minimal and maximal gain will be determined that the camera
         *  must not exceed in auto gain/exposure mode.
         *
         *  @param Camera a handle from a camera that has been opened before
         *  @param MinGain the minimal allowed gain value
         *  @param MaxGain the maximal allowed gain value
         *  @return SVGigE_SUCCESS or an appropriate SVGigE error code
         */

        public unsafe
        SVSGigeApiReturn
        Gige_Camera_setAutoGainLimits(int Camera,
                               float MinGain,
                               float MaxGain)
        {
            return Camera_setAutoGainLimits(Camera, MinGain, MaxGain);
        }

        /** Get auto gain limits
         *  The minimal and maximal gain will be returned that the camera
         *  must not exceed in auto gain/exposure mode.
         *
         *  @param Camera a handle from a camera that has been opened before
         *  @param ProgrammedMinGain a pointer to the minimal allowed gain value
         *  @param ProgrammedMaxGain a pointer to the maximal allowed gain value
         *  @return SVGigE_SUCCESS or an appropriate SVGigE error code
         */

        public unsafe
        SVSGigeApiReturn
        Gige_Camera_getAutoGainLimits(int Camera,
                               float* ProgrammedMinGain,
                               float* ProgrammedMaxGain)
        {
            return Camera_getAutoGainLimits(Camera, ProgrammedMinGain, ProgrammedMaxGain);
        }

        /** Set auto exposure limits
         *  The minimal and maximal exposure will be determined that the camera
         *  must not exceed in auto gain/exposure mode.
         *
         *  @param Camera a handle from a camera that has been opened before
         *  @param MinGain the minimal allowed exposure value
         *  @param MaxGain the maximal allowed exposure value
         *  @return SVGigE_SUCCESS or an appropriate SVGigE error code
         */

        public unsafe
        SVSGigeApiReturn
        Gige_Camera_setAutoExposureLimits(int Camera,
                                   float MinExposure,
                                   float MaxExposure)
        {
            return Camera_setAutoExposureLimits(Camera, MinExposure, MaxExposure);
        }

        /** Set auto exposure limits
         *  The minimal and maximal exposure will be determined that the camera
         *  must not exceed in auto gain/exposure mode.
         *
         *  @param Camera a handle from a camera that has been opened before
         *  @param ProgrammedMinExposure the minimal allowed exposure value
         *  @param ProgrammedMaxExposure the maximal allowed exposure value
         *  @return SVGigE_SUCCESS or an appropriate SVGigE error code
         */

        public unsafe
        SVSGigeApiReturn
        Gige_Camera_getAutoExposureLimits(int Camera,
                                   float* ProgrammedMinExposure,
                                   float* ProgrammedMaxExposure)
        {
            return Camera_getAutoExposureLimits(Camera, ProgrammedMinExposure, ProgrammedMaxExposure);
        }


        //------------------------------------------------------------------------------
        // 15 - Controlling camera: Acquisition trigger
        //------------------------------------------------------------------------------

        /** Set acquisition control.
         *  The camera's acquisition will be controlled (start/stop).
         *
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param AcquisitionControl the new setting for acquisition control
         *  @return success or error code
         */
        public unsafe
        SVSGigeApiReturn
          Gige_Camera_setAcquisitionControl(int hCamera, ACQUISITION_CONTROL AcquisitionControl)
        {
            return Camera_setAcquisitionControl(hCamera, AcquisitionControl);
        }


        /** Get acquisition control.
         *  The camera's current acquisition control (start/stop) will be returned.
         *
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param AcquisitionControl the currently programmed setting for acquisition control
         *  @return success or error code
         */
        public unsafe
        SVSGigeApiReturn
          Gige_Camera_getAcquisitionControl(int hCamera, ACQUISITION_CONTROL* AcquisitionControl)
        {
            return Camera_getAcquisitionControl(hCamera, AcquisitionControl);
        }

        /**
         * Set acquisition mode.
         * The camera's acquisition mode will be set to the selected value
         *
         * @see CameraContainer_getCamera()
         * @param hCamera a camera handle received from CameraContainer_getCamera()
         * @param AcquisitionMode the new setting for acquisition mode
         * @return success or error code
         */
        public unsafe
            SVSGigeApiReturn
            Gige_Camera_setAcquisitionMode(int hCamera,
            ACQUISITION_MODE AcquisitionMode)
        {
            return Camera_setAcquisitionMode(hCamera, AcquisitionMode);
        }


        /** Set Acquisition mode and start
         *  In addition to setting the acquisition mode it can be determined whether
         *  acquisition control will go to enabled or stay on disabled after the new
         *  acquisition mode has been adjusted
         *
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param AcquisitionMode the new setting for acquisition mode
         *  @param AcquisitionStart whether camera control switches to START immediately
         *  @return success or error code
         */
        public unsafe
            SVSGigeApiReturn
            Gige_Camera_setAcquisitionModeAndStart(int hCamera, ACQUISITION_MODE AcquisitionMode,
                                            bool AcquisitionStart)
        {
            return Camera_setAcquisitionModeAndStart(hCamera, AcquisitionMode, AcquisitionStart);
        }

        /**
         * Get acquisition mode.
         * The camera's current acquisition mode will be returned
         *
         * @see CameraContainer_getCamera()
         * @param hCamera a camera handle received from CameraContainer_getCamera()
         * @param AcquisitionMode the currently programmed setting for acquisition mode
         * @return success or error code
         */
        public unsafe
            SVSGigeApiReturn
            Gige_Camera_getAcquisitionMode(int hCamera,
            ref ACQUISITION_MODE AcquisitionMode)
        {
            SVSGigeApiReturn rval;
            fixed (ACQUISITION_MODE* ProgrammedAcquisitionMode = &AcquisitionMode)
            {
                rval = Camera_getAcquisitionMode(hCamera, ProgrammedAcquisitionMode);
            }

            return rval;
        }


        /** Software trigger.
         *  The camera will be triggerred for starting a new acquisition cycle.
         *  A mandatory pre-requisition for a successfull software trigger is to have
         *  the camera set to ACQUISITION_MODE_SOFTWARE_TIGGER before.
         *
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @return success or error code
         */
        public unsafe
        SVSGigeApiReturn
          Gige_Camera_softwareTrigger(int hCamera)
        {
            return Camera_softwareTrigger(hCamera);
        }


        /** Software trigger ID. (defined but not yet available)
         *  The camera will be triggerred for starting a new acquisition cycle.
         *  A mandatory pre-requisition for a successfull software trigger is to have
         *  the camera set to ACQUISITION_MODE_SOFTWARE_TIGGER before.
         *  In addition to a usual software trigger, an ID will be accepted that
         *  can be written into the image on demand, e.g. for maintaining a unique
         *  trigger/image reference
         *
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param TriggerID an ID to be transferred into first bytes of resulting image data
         *  @return success or error code
         */
        public unsafe
        SVSGigeApiReturn
          Gige_Camera_softwareTriggerID(int hCamera, int TriggerID)
        {
            return Camera_softwareTriggerID(hCamera, TriggerID);
        }


        /** Software trigger ID enable. (defined but not yet available)
         *  The "software trigger ID" mode will be enabled respectively disabled
         *
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param TriggerIDEnable whether "trigger ID" will be enabled or disabled
         *  @return success or error code
         */
        public unsafe
        SVSGigeApiReturn
          Gige_Camera_softwareTriggerIDEnable(int hCamera, bool TriggerIDEnable)
        {
            return Camera_softwareTriggerIDEnable(hCamera, TriggerIDEnable);
        }


        /**
         * Set trigger polarity
         * The camera's trigger polarity will be set to the selected value
         *
         * @see CameraContainer_getCamera()
         * @param hCamera a camera handle received from CameraContainer_getCamera()
         * @param TriggerPolarity the new setting for trigger polarity
         * @return success or error code
         */
        public unsafe
            SVSGigeApiReturn
            Gige_Camera_setTriggerPolarity(int hCamera,
            TRIGGER_POLARITY TriggerPolarity)
        {
            return Camera_setTriggerPolarity(hCamera, TriggerPolarity);
        }

        /**
         * Get trigger polarity
         * The camera's current trigger polarity will be returned
         *
         * @see CameraContainer_getCamera()
         * @param hCamera a camera handle received from CameraContainer_getCamera()
         * @param TriggerPolarity the currently programmed setting for trigger polarity
         * @return success or error code
         */
        public unsafe
            SVSGigeApiReturn
            Gige_Camera_getTriggerPolarity(int hCamera,
            GigeApi.TRIGGER_POLARITY* ProgrammedTriggerPolarity)
        {
            return Camera_getTriggerPolarity(hCamera, ProgrammedTriggerPolarity);
        }



        //------------------------------------------------------------------------------
        // 16 - Controlling camera: Strobe
        //------------------------------------------------------------------------------









        /**
         * Set strobe polarity
         * The camera's strobe polarity will be set to the selected value
         *
         * @see CameraContainer_getCamera()
         * @param hCamera a camera handle received from CameraContainer_getCamera()
         * @param StrobePolarity the new setting for strobe polarity
         * @return success or error code
         */
        public unsafe
            SVSGigeApiReturn
            Gige_Camera_setStrobePolarity(int hCamera,
            STROBE_POLARITY StrobePolarity)
        {
            return Camera_setStrobePolarity(hCamera, StrobePolarity);

        }

        /** Set strobe polarity extended
        *  The camera's strobe polarity will be set to the selected value
        *
        *  @see CameraContainer_getCamera()
        *  @param hCamera a camera handle received from CameraContainer_getCamera()
        *  @param StrobePolarity the new setting for strobe polarity
        *  @param StrobIndex the index of the current strobe channel 
        *  @return success or error code
        */

        public unsafe
                   SVSGigeApiReturn
                   Gige_Camera_setStrobePolarityExtended(int hCamera, STROBE_POLARITY StrobePolarity, int StrobeIndex)
        {
            return Camera_setStrobePolarityExtended(hCamera, StrobePolarity, StrobeIndex);
        }

        /**
         * Get strobe polarity
         * The camera's current strobe polarity will be returned
         *
         * @see CameraContainer_getCamera()
         * @param hCamera a camera handle received from CameraContainer_getCamera()
         * @param StrobePolarity the currently programmed setting for strobe polarity
         * @return success or error code
         */
        public unsafe
            SVSGigeApiReturn
            Gige_Camera_getStrobePolarity(int hCamera,
            STROBE_POLARITY* ProgrammedStrobePolarity)
        {
            return Camera_getStrobePolarity(hCamera, ProgrammedStrobePolarity);
        }

        /** Get strobe polarity extended
        *  The camera's current strobe polarity will be returned
        *
        *  @see CameraContainer_getCamera()
        *  @param hCamera a camera handle received from CameraContainer_getCamera()
        *  @param StrobePolarity the currently programmed setting for strobe polarity
        *  @param StrobIndex the index of the current strobe channel 
        *  @return success or error code
        */

        public unsafe
                  SVSGigeApiReturn
                    Gige_Camera_getStrobePolarityExtended(int hCamera, STROBE_POLARITY* ProgrammedStrobePolarity, int StrobeIndex)
        {
            return Camera_getStrobePolarityExtended(hCamera, ProgrammedStrobePolarity, StrobeIndex);
        }



        /**
         * Set strobe position
         * The camera's strobe position in micro seconds relative to the trigger
         * pulse will be set to the selected value
         *
         * @see CameraContainer_getCamera()
         * @param hCamera a camera handle received from CameraContainer_getCamera()
         * @param StrobePosition the new value for strobe position in microseconds
         * @return success or error code
         */
        public unsafe
            SVSGigeApiReturn
            Gige_Camera_setStrobePosition(int hCamera,
            float StrobePosition)
        {
            return Camera_setStrobePosition(hCamera, StrobePosition);
        }

        /** Set strobe position extended
*  The camera's strobe position in micro seconds relative to the trigger
*  pulse will be set to the selected value
*
*  @see CameraContainer_getCamera()
*  @param hCamera a camera handle received from CameraContainer_getCamera()
*  @param StrobePosition the new value for strobe position in microseconds
*  @param StrobIndex the index of the current strobe channel 
*  @return success or error code
*/

        public unsafe
                    SVSGigeApiReturn
                    Gige_Camera_setStrobePositionExtended(int hCamera, float StrobePosition, int StrobeIndex)
        {
            return Camera_setStrobePositionExtended(hCamera, StrobePosition, StrobeIndex);
        }

        /**
         * Get strobe position
         * The camera's current strobe position will be returned in micro seconds
         * relative to the trigger pulse
         *
         * @see CameraContainer_getCamera()
         * @param hCamera a camera handle received from CameraContainer_getCamera()
         * @param StrobePosition the currently programmed value for strobe position in microseconds
         * @return success or error code
         */
        public unsafe
            SVSGigeApiReturn
            Gige_Camera_getStrobePosition(int hCamera,
            float* ProgrammedStrobePosition)
        {
            return Camera_getStrobePosition(hCamera, ProgrammedStrobePosition);
        }

        /** Get strobe position extended
 *  The camera's current strobe position will be returned in micro seconds
 *  relative to the trigger pulse
 *
 *  @see CameraContainer_getCamera()
 *  @param hCamera a camera handle received from CameraContainer_getCamera()
 *  @param StrobePosition the currently programmed value for strobe position in microseconds
 *  @param StrobIndex the index of the current strobe channel 
 *  @return success or error code
 */
        public unsafe
          SVSGigeApiReturn
          Gige_Camera_getStrobePositionExtended(int hCamera, float* ProgrammedStrobePosition, int StrobeIndex)
        {
            return Camera_getStrobePositionExtended(hCamera, ProgrammedStrobePosition, StrobeIndex);
        }

        /**
         * Set strobe duration
         * The camera's strobe duration in micro seconds will be set to the selected
         * value
         *
         * @see CameraContainer_getCamera()
         * @param hCamera a camera handle received from CameraContainer_getCamera()
         * @param StrobeDuration the new value for strobe duration in microseconds
         * @return success or error code
         */
        public unsafe SVSGigeApiReturn
            Gige_Camera_setStrobeDuration(int hCamera,
            float StrobeDuration)
        {
            return Camera_setStrobeDuration(hCamera, StrobeDuration);
        }



        /** Set strobe duration extended
         *  The camera's strobe duration in micro seconds will be set to the selected
         *  value
         *
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param StrobeDuration the new value for strobe duration in microseconds
         *  @param StrobIndex the index of the current strobe channel 
         *  @return success or error code
         */
        public unsafe SVSGigeApiReturn
            Gige_Camera_setStrobeDurationExtended(int hCamera, float StrobeDuration, int StrobeIndex)
        {
            return Camera_setStrobeDurationExtended(hCamera, StrobeDuration, StrobeIndex);
        }


        /**
         * Get strobe duration
         * The camera's current strobe duration in micro seconds will be returned
         *
         * @see CameraContainer_getCamera()
         * @param hCamera a camera handle received from CameraContainer_getCamera()
         * @param StrobeDuration the currently programmed value for strobe duration in microseconds
         * @return success or error code
         */
        public unsafe
            SVSGigeApiReturn
            Gige_Camera_getStrobeDuration(int hCamera,
            float* ProgrammedStrobeDuration)
        {
            return Camera_getStrobeDuration(hCamera, ProgrammedStrobeDuration);
        }

        /** Get strobe duration extended
         *  The camera's current strobe duration in micro seconds will be returned
         *
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param StrobeDuration the currently programmed value for strobe duration in microseconds
         *  @param StrobIndex the index of the current strobe channel 
         *  @return success or error code
         */
        public unsafe
             SVSGigeApiReturn
            Gige_Camera_getStrobeDurationExtended(int hCamera, float* ProgrammedStrobeDuration, int StrobeIndex)
        {
            return Camera_getStrobeDurationExtended(hCamera, ProgrammedStrobeDuration, StrobeIndex);
        }


        /** Get maximal strobe position
         *  The camera's maximal strobe position (delay) will be returned in micro seconds
         *
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param StrobePositionMax the maximal value for strobe position in microseconds
         *  @return success or error code
         */
        public unsafe
            SVSGigeApiReturn
          Gige_Camera_getStrobePositionMax(int hCamera, float* MaxStrobePosition)
        {
            return Camera_getStrobePositionMax(hCamera, MaxStrobePosition);
        }


        /** Get strobe position increment
         *  The camera's strobe position increment will be returned in micro seconds
         *
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param StrobePositionIncrement the strobe position increment in microseconds
         *  @return success or error code
         */
        public unsafe
        SVSGigeApiReturn
          Gige_Camera_getStrobePositionIncrement(int hCamera, float* StrobePositionIncrement)
        {
            return Camera_getStrobePositionIncrement(hCamera, StrobePositionIncrement);
        }


        //------------------------------------------------------------------------------
        // 17 - Controlling camera: Tap balance
        //------------------------------------------------------------------------------

        /** Save tap balance settings.
         *  Current settings for tap balance will be saved into a XML file. Usually the
         *  tap balance is adjusted during camera production. Whenever a need exists for
         *  changing those factory settings, e.g. for balancing image sensor characteristics
         *  dependent on gain, particular settings can be determined, saved to files and
         *  later loaded on demand.
         *
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param Filename a complete path and filename where to save the settings
         *  @return success or error code
         */
        public unsafe
        SVSGigeApiReturn
          Gige_Camera_saveTapBalanceSettings(int hCamera, sbyte* Filename)
        {
            return Camera_saveTapBalanceSettings(hCamera, Filename);
        }



        /** Load tap balance settings.
         *  New settings for tap balance will be loaded from a XML file.
         *
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param Filename a complete path and filename where to load the settings from
         *  @return success or error code
         */
        public unsafe
         SVSGigeApiReturn
          Gige_Camera_loadTapBalanceSettings(int hCamera, sbyte* Filename)
        {
            return Camera_loadTapBalanceSettings(hCamera, Filename);
        }



        /** Set tap configuration
         *  The camera will be controlled for working with one or two taps
         *
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param TapCount the number of taps (1, 2) to be used by the camera
         *  @return success or error code
         */
        public unsafe
        SVSGigeApiReturn
          Gige_Camera_setTapConfiguration(int hCamera, int TapCount)
        {
            return Camera_setTapConfiguration(hCamera, TapCount);
        }

        /** Get tap configuration
         *  The camera will be queried whether it is working with one or two taps
         *
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param TapCount the number of taps (1, 2) currently used by the camera is returned
         *  @return success or error code
         */
        public unsafe
        SVSGigeApiReturn
          Gige_Camera_getTapConfiguration(int hCamera, int* TapCount)
        {
            return Camera_getTapConfiguration(hCamera, TapCount);
        }

        /** Set auto tap balance mode
         *  One of the modes (OFF,ONCE,CONTINUOUS,RESET) will be applied for an auto
         *  tap balance procedure.
         *
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param AutoTapBalanceMode the mode for auto tap balancing to be activated
         *  @return success or error code
         */
        public unsafe
        SVSGigeApiReturn
          Gige_Camera_setAutoTapBalanceMode(int hCamera, SVGIGE_AUTO_TAP_BALANCE_MODE AutoTapBalanceMode)
        {
            return Camera_setAutoTapBalanceMode(hCamera, AutoTapBalanceMode);
        }

        /** Get auto tap balance mode
         *  Currently adjusted auto tap balance mode will be returned.
         *
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param AutoTapBalanceMode a pointer to a value for auto tap balancing
         *  @return success or error code
         */
        public unsafe
        SVSGigeApiReturn
          Gige_Camera_getAutoTapBalanceMode(int hCamera, SVGIGE_AUTO_TAP_BALANCE_MODE* AutoTapBalanceMode)
        {
            return Camera_getAutoTapBalanceMode(hCamera, AutoTapBalanceMode);
        }


        /** Set tap balance
         *  A provided tap balance in [dB] will be transferred to camera.
         *
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param TapBalance the new value for tap balance to be activated
         *  @return success or error code
         */
        public unsafe
        SVSGigeApiReturn
         Gige_Camera_setTapBalance(int hCamera, float TapBalance)
        {
            return Camera_setTapBalance(hCamera, TapBalance);
        }

        /** Get tap balance
         *  Currently adjusted tap balance in [dB] will be retrieved from camera.
         *
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param TapBalance a pointer to a tap balance value
         *  @return success or error code
         */
        public unsafe
        SVSGigeApiReturn
          Gige_Camera_getTapBalance(int hCamera, float* TapBalance)
        {
            return Camera_getTapBalance(hCamera, TapBalance);
        }



        public unsafe
        SVSGigeApiReturn
          Gige_Camera_setTapGain(int hCamera, float TapGain, SVGIGE_TAP_SELECT TapSelect)
        {
            return Camera_setTapGain(hCamera, TapGain, TapSelect);

        }

        public unsafe
         SVSGigeApiReturn
           Gige_Camera_getTapGain(int hCamera, float* TapBalance, SVGIGE_TAP_SELECT TapSelect)
        {
            return Camera_getTapGain(hCamera, TapBalance, TapSelect);

        }





        //------------------------------------------------------------------------------
        // 18 - Controlling camera: Image parameter
        //------------------------------------------------------------------------------

        /** Get imager width.
         *  The imager width will be retrieved from the camera
         *
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param ImagerWidth a reference to the imager width value
         *  @return success or error code
         */
        public unsafe
        SVSGigeApiReturn
         Gige_Camera_getImagerWidth(int hCamera, int* ImagerWidth)
        {
            return Camera_getImagerWidth(hCamera, ImagerWidth);
        }

        /** Get imager height.
         *  The imager height will be retrieved from the camera
         *
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param ImagerHeight a reference to the imager height value
         *  @return success or error code
         */
        public unsafe
        SVSGigeApiReturn
        Gige_Camera_getImagerHeight(int hCamera, int* ImagerHeight)
        {
            return Camera_getImagerHeight(hCamera, ImagerHeight);
        }

        /**
         * Get size X.
         * The horizontal picture size X will be retrieved from the camera
         *
         * @see CameraContainer_getCamera()
         * @param hCamera a camera handle received from CameraContainer_getCamera()
         * @param SizeX a reference to the size X value
         * @return success or error code
         */
        public unsafe
            SVSGigeApiReturn
            Gige_Camera_getSizeX(int hCamera,
            ref int SizeX)
        {
            SVSGigeApiReturn rval;
            fixed (int* sx = &SizeX)
            {
                rval = Camera_getSizeX(hCamera, sx);
            }
            return rval;
        }

        /**
         * Get size Y.
         * The vertical picture size Y will be retrieved from the camera
         *
         * @see CameraContainer_getCamera()
         * @param hCamera a camera handle received from CameraContainer_getCamera()
         * @param SizeY a reference to the size Y value
         * @return success or error code
         */
        public unsafe
            SVSGigeApiReturn
            Gige_Camera_getSizeY(int hCamera,
            ref int SizeY)
        {
            SVSGigeApiReturn rval;
            fixed (int* sy = &SizeY)
            {
                rval = Camera_getSizeY(hCamera, sy);
            }
            return rval;
        }

        /**
         * Get pitch.
         * The number of bytes in a row will be returned
         *
         * @see CameraContainer_getCamera()
         * @param hCamera a camera handle received from CameraContainer_getCamera()
         * @param Pitch a reference to the pitch value
         * @return success or error code
         */
        public unsafe
            SVSGigeApiReturn
            Gige_Camera_getPitch(int hCamera,
            int* Pitch)
        {
            return Camera_getPitch(hCamera, Pitch);

        }

        /**
         * Get image size.
         * The number of bytes in an image will be returned
         *
         * @see CameraContainer_getCamera()
         * @param hCamera a camera handle received from CameraContainer_getCamera()
         * @param ImageSize a reference to the image size value
         * @return success or error code
         */
        public unsafe
            SVSGigeApiReturn
            Gige_Camera_getImageSize(int hCamera,
            int* ImageSize)
        {
            return Camera_getImageSize(hCamera, ImageSize);
        }

        /**
             * Set binning mode.
             * The camera's binning mode will be set to the selected value
             *
             * @see CameraContainer_getCamera()
             * @param hCamera a camera handle received from CameraContainer_getCamera()
             * @param BinningMode the new setting for binning mode
             * @return success or error code
             */
        public unsafe
            SVSGigeApiReturn
            Gige_Camera_setBinningMode(int hCamera,
            BINNING_MODE BinningMode)
        {
            return Camera_setBinningMode(hCamera, BinningMode);
        }

        /**
             * Get binning mode.
             * The camera's current binning mode will be returned
             *
             * @see CameraContainer_getCamera()
             * @param hCamera a camera handle received from CameraContainer_getCamera()
             * @param BinningMode the currently programmed setting for binning mode
             * @return success or error code
             */
        public unsafe
            SVSGigeApiReturn
            Gige_Camera_getBinningMode(int hCamera,
            BINNING_MODE* ProgrammedBinningMode)
        {
            return Camera_getBinningMode(hCamera, ProgrammedBinningMode);
        }


        /** Set area of interest (AOI)
         *  The camera will be switched to partial scan mode and an AOI will be set
         *
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param SizeX the number of pixels in one row
         *  @param SizeY the number of scan lines
         *  @param OffsetX a left side offset of the scanned area
         *  @param OffsetY an upper side offset of the scanned area
         *  @return success or error code
         */
        public unsafe
        SVSGigeApiReturn
          Gige_Camera_setAreaOfInterest(int hCamera, int SizeX, int SizeY, int OffsetX, int OffsetY)
        {
            return Camera_setAreaOfInterest(hCamera, SizeX, SizeY, OffsetX, OffsetY);
        }

        /** Get area of interest(AOI)
         *  The currently set parameters for partial scan will be returned
         *
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param ProgrammedSizeX the number of pixels in one row
         *  @param ProgrammedSizeY the number of scan lines
         *  @param ProgrammedOffsetX a left side offset of the scanned area
         *  @param ProgrammedOffsetY an upper side offset of the scanned area
         *  @return success or error code
         */
        public unsafe
        SVSGigeApiReturn
             Gige_Camera_getAreaOfInterest(int hCamera, int* ProgrammedSizeX, int* ProgrammedSizeY,
                                   int* ProgrammedOffsetX, int* ProgrammedOffsetY)
        {
            return Camera_getAreaOfInterest(hCamera, ProgrammedSizeX, ProgrammedSizeY, ProgrammedOffsetX, ProgrammedOffsetY);
        }

        /** Get minimal/maximal area of interest(AOI).
         *  The boundaries for partial scan will be returned
         *
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param MinSizeX the minimal AOI width
         *  @param MinSizeY the minimal AOI height
         *  @param MaxSizeX the maximal AOI width
         *  @param MaxSizeY the maximal AOI height
         *  @return success or error code
         */
        public unsafe
        SVSGigeApiReturn
         Gige_Camera_getAreaOfInterestRange(int hCamera, int* MinSizeX, int* MinSizeY, int* MaxSizeX, int* MaxSizeY)
        {
            return Camera_getAreaOfInterestRange(hCamera, MinSizeX, MinSizeY, MaxSizeX, MaxSizeY);
        }

        /** Get area of interest(AOI) increment
         *  The increment for partial scan parameters will be returned
         *
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param SizeXIncrement the increment for AOI width
         *  @param SizeYIncrement the increment for AOI height
         *  @param OffsetXIncrement the increment for AOI width offset
         *  @param OffsetYIncrement the increment for AOI height offset
         *  @return success or error code
         */
        public unsafe
        SVSGigeApiReturn
          Gige_Camera_getAreaOfInterestIncrement(int hCamera,
                                            int* SizeXIncrement,
                                            int* SizeYIncrement,
                                            int* OffsetXIncrement,
                                            int* OffsetYIncrement)
        {
            return Camera_getAreaOfInterestIncrement(hCamera, SizeXIncrement, SizeYIncrement, OffsetXIncrement, OffsetYIncrement);
        }

        /** Reset timestamp counter
         *  The camera's timestamp counter will be set to zero.
         *
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @return success or error code
         */
        public unsafe
        SVSGigeApiReturn
          Gige_Camera_resetTimestampCounter(int hCamera)
        {
            return Camera_resetTimestampCounter(hCamera);
        }

        /** Get timestamp counter
         *  Current value of the camera's timestamp counter will be returned.
         *
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param TimestampCounter the current value of the timestamp counter
         *  @return success or error code
         */
        public unsafe
        SVSGigeApiReturn
          Gige_Camera_getTimestampCounter(int hCamera,
                                     double* TimestampCounter)
        {
            return Camera_getTimestampCounter(hCamera, TimestampCounter);
        }

        /** Get timestamp tick frequency
         *  A camera's timestamp tick frequency will be returned.
         *
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param TimestampTickFrequency the camera's timestamp tick frequency
         *  @return success or error code
         */
        public unsafe
        SVSGigeApiReturn
          Gige_Camera_getTimestampTickFrequency(int hCamera,
                                           double* TimestampCounter)
        {
            return Camera_getTimestampTickFrequency(hCamera, TimestampCounter);
        }


        //.......................Piv Mode ....................

        /** Set a new PIV mode
         *  The camera's PIV mode will be enabled or disabled.
         *
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param PivMode the new setting for PivMode
         *  @return success or error code
        */

        public unsafe
        SVSGigeApiReturn Gige_Camera_setPivMode(int hCamera, PIV_MODE PivMode)
        {
            return Camera_setPivMode(hCamera, PivMode);
        }


        /**
         * Get PIV Mode 
         * Check if camera's PIV mode is enabled or disabled.
         *  The state of camera's current Piv mode will be returned
         *
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param ProgrammedPivMode the currently programmed setting for PivMode
         *  @return success or error code
         */
        public unsafe
        SVSGigeApiReturn Gige_Camera_getPivMode(int hCamera, PIV_MODE* ProgrammedPivMode)
        {
            return Camera_getPivMode(hCamera, ProgrammedPivMode);
        }



        //.......................Debouncer....................

        /** Set Debouncer  duration
        *   The camera's Debouncer duration will be set to the selected value
        *
        *  @param hCamera a camera handle received from CameraContainer_getCamera()
        *  @param DebouncerDuration the new setting for DebouncerDuration
        *  @return success or error code
         */
        public unsafe
        SVSGigeApiReturn Gige_Camera_setDebouncerDuration(int hCamera,
                                           float DebouncerDuration)
        {
            return Camera_setDebouncerDuration(hCamera,
                                           DebouncerDuration);
        }

        /** Get Debouncer  duration
         *  The camera's Debouncer  duration will be returned
         *
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param ProgrammedDuration the currently programmed setting for DebouncerDuration.
         *  @return success or error code
         */
        public unsafe
        SVSGigeApiReturn Gige_Camera_getDebouncerDuration(int hCamera,
                               float* ProgrammedDuration)
        {
            return Camera_getDebouncerDuration(hCamera,
                                ProgrammedDuration);
        }



        //.......................Prescaler....................

        /** Set prescaler devisor
         *   The camera's prescaler Devisor will be set to the selected value
         *
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param PrescalerDevisor the new setting for PrescalerDevisor
         *  @return success or error code
         */
        public unsafe
        SVSGigeApiReturn Gige_Camera_setPrescalerDevisor(int hCamera,
                               uint PrescalerDevisor)
        {
            return Camera_setPrescalerDevisor(hCamera,
                                PrescalerDevisor);
        }

        /** Get prescaler devisor
         *  The camera's prescaler devisor will be returned
         *
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param ProgrammedPrescalerDevisor the currently programmed setting for PrescalerDevisor. 
         *  @return success or error code
         */

        public unsafe
        SVSGigeApiReturn Gige_Camera_getPrescalerDevisor(int hCamera,
              uint* ProgrammedPrescalerDevisor)
        {
            return Gige_Camera_getPrescalerDevisor(hCamera,
                               ProgrammedPrescalerDevisor);

        }






        //.......................Sequencer....................



        public unsafe
        SVSGigeApiReturn Gige_Camera_loadSequenceParameters(int hCamera,
                              string Filename)
        {

            // char[] charArray = Filename.ToCharArray();
            //  fixed (char* pCharFile = Filename)
            return Camera_loadSequenceParameters(hCamera,
                                   Filename);

        }



        public unsafe
          SVSGigeApiReturn
            Gige_Camera_startSequencer(int hCamera)
        {
            return Camera_startSequencer(hCamera);
        }




        //------------------------------------------------------------------------------
        // 19 - Controlling camera: Image appearance
        //------------------------------------------------------------------------------



        /**
         * Get pixel type.
         * The pixel type will be retrieved from the camera
         *
         * @see CameraContainer_getCamera()
         * @param hCamera a camera handle received from CameraContainer_getCamera()
         * @param PixelType a reference to the pixel type value
         * @return success or error code
         */
        public unsafe
        SVSGigeApiReturn Gige_Camera_getPixelType(int hCamera, ref GVSP_PIXEL_TYPE PixelType)
        {

            SVSGigeApiReturn apiReturn;

            fixed (GVSP_PIXEL_TYPE* type = &(PixelType))
            {
                apiReturn = Camera_getPixelType(hCamera, type);
            }

            return apiReturn;

            // return Camera_getPixelType(hCamera, PixelType);
        }



        /**
         * Set pixel depth.
         * The number of bits for a pixel will be set to 8, 12 or 16 bits. Before this function 
         * is called the camera's feature vector should be queried whether the desired pixel depth
         * is supported
         *
         * @see Camera_isCameraFeature()
         * @see CameraContainer_getCamera()
         * @param hCamera a camera handle received from CameraContainer_getCamera()
         * @param PixelDepth the intended value for pixel depth
         * @return success or error code
         */

        public unsafe
        SVSGigeApiReturn
        Gige_Camera_setPixelDepth(int hCamera, SVGIGE_PIXEL_DEPTH PixelDepth)
        {
            return Camera_setPixelDepth(hCamera, PixelDepth);
        }

        /**
         * Get pixel depth.
         * The camera's current setting for pixel depth will be queried.
         *
         * @see CameraContainer_getCamera()
         * @param hCamera a camera handle received from CameraContainer_getCamera()
         * @param PixelDepth an enum for the number of bits in a pixel will be returned
         * @return success or error code
         */

        public unsafe
        SVSGigeApiReturn
        Gige_Camera_getPixelDepth(int hCamera, ref SVGIGE_PIXEL_DEPTH PixelDepth)
        {

            SVSGigeApiReturn apiReturn;

            fixed (SVGIGE_PIXEL_DEPTH* depth = &(PixelDepth))
            {
                apiReturn = Camera_getPixelDepth(hCamera, depth);
            }

            return apiReturn;
        }




        /** setWhiteBalance.
         *  The provided values will be applied for white balance.
         *
         *  NOTE: The color component strength for Red, Green and Blue can either be
         *        provided by user or they can conveniently be calculated inside an image
         *        callback using the Image_estimateWhiteBalance() function.
         *
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param Red balanced value for red color
         *  @param Green balanced value for green color
         *  @param Blue balanced value for blue color
         *  @return success or error code
         */
        public unsafe
            SVSGigeApiReturn
          Gige_Camera_setWhiteBalance(int hCamera, float Red, float Green, float Blue)
        {
            return Camera_setWhiteBalance(hCamera, Red, Green, Blue);
        }

        /** getWhiteBalance.
         *  Currently set values for white balance will be returned.
         *  Previously adjusted values will be returned either unchanged or adjusted
         *  if necessary. The returned values will be 100 and above where the color
         *  which got 100 assigned will be transferred unchanged, however two
         *  other color components might be enhanced above 100 for each image.
         *
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param Red balanced value for red color
         *  @param Green balanced value for green color
         *  @param Blue balanced value for blue color
         *  @return success or error code
         */
        public unsafe
            SVSGigeApiReturn
          Gige_Camera_getWhiteBalance(int hCamera, float* Red, float* Green, float* Blue)
        {
            return Camera_getWhiteBalance(hCamera, Red, Green, Blue);
        }

        /** getWhiteBalanceMax.
         *  The maximal white-balance value for amplifying colors will be returned.
         *  A value of 1.0 is the reference for a balanced situation.
         *
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param WhiteBalanceMax the maximal white-balance (e.g. 4.0 or 2.0)
         *  @return success or error code
         */
        public unsafe
            SVSGigeApiReturn
          Gige_Camera_getWhiteBalanceMax(int hCamera, float* WhiteBalanceMax)
        {
            return Camera_getWhiteBalanceMax(hCamera, WhiteBalanceMax);
        }

        /** setGammaCorrection.
         *  A lookup table will be generated based on given gamma correction.
         *  Subsequently the lookup table will be uploaded to the camera.
         *  A gamma correction is supported in a range 0.4 - 2.5
         *
         *  @param Camera a handle from a camera that has been opened before
         *  @param GammaCorrection a gamma correction factor
         *  @return SVGigE_SUCCESS or an appropriate SVGigE error code
         */
        public unsafe
            SVSGigeApiReturn
            Gige_Camera_setGammaCorrection(int Camera, float GammaCorrection)
        {
            return Camera_setGammaCorrection(Camera, GammaCorrection);
        }

        /** setGammaCorrectionExt.
         *  A lookup table will be generated based on given gamma correction.
         *  Additionally, a digital gain and offset will be taken into account.
         *  Subsequently the lookup table will be uploaded to the camera.
         *  A gamma correction is supported in a range 0.4 - 2.5
         *
         *  @param Camera a handle from a camera that has been opened before
         *  @param GammaCorrection a gamma correction factor
         *  @return SVGigE_SUCCESS or an appropriate SVGigE error code
         */
        public unsafe
            SVSGigeApiReturn
            Gige_Camera_setGammaCorrectionExt(int Camera, float GammaCorrection, float DigitalGain, float DigitalOffset)
        {
            return Camera_setGammaCorrectionExt(Camera, GammaCorrection, DigitalGain, DigitalOffset);
        }

        /** setLowpassFilter.
          *  A filter will be enabled/disabled which smoothes an image inside
          *  a camera accordingly to a given algorithm, e.g. 3x3.
          *
          *  @param Camera a handle from a camera that has been opened before
          *  @param LowpassFilter a control value for activating/deactivating smoothing
          *  @return SVGigE_SUCCESS or an appropriate SVGigE error code
          */
        public unsafe
            SVSGigeApiReturn
          Gige_Camera_setLowpassFilter(int Camera, LOWPASS_FILTER LowpassFilter)
        {
            return Camera_setLowpassFilter(Camera, LowpassFilter);
        }

        /** getLowpassFilter.
          *  Current mode of a lowpass filter will be retrieved from camera.
          *
          *  @param Camera a handle from a camera that has been opened before
          *  @param LowpassFilter the currently programmed lowpass filter will be returned
          *  @return SVGigE_SUCCESS or an appropriate SVGigE error code
          */
        public unsafe
            SVSGigeApiReturn
          Gige_Camera_getLowpassFilter(int Camera, LOWPASS_FILTER* ProgrammedLowpassFilter)
        {
            return Camera_getLowpassFilter(Camera, ProgrammedLowpassFilter);
        }


        /** setLookupTableMode.
         *  The look-up table mode will be switched on or off
         *
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param LUTMode new setting for look-up table mode
         *  @return success or error code
         */
        public unsafe
            SVSGigeApiReturn
          Gige_Camera_setLookupTableMode(int hCamera, LUT_MODE LUTMode)
        {
            return Camera_setLookupTableMode(hCamera, LUTMode);
        }

        /** Get look-up table mode.
         *  The currently programmed look-up table mode will be retrieved
         *
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param ProgrammedLUTMode currently programmed look-up table mode
         *  @return success or error code
         */
        public unsafe
            SVSGigeApiReturn
          Gige_Camera_getLookupTableMode(int hCamera, LUT_MODE* ProgrammedLUTMode)
        {
            return Camera_getLookupTableMode(hCamera, ProgrammedLUTMode);
        }


        /** setLookupTable.
         *  A user-defined lookup table will be uploaded to the camera. The size has to match
         *  the lookup table size that is supported by the camera (1024 for 10to8 or 4096 for 12to8).
         *
         *  @see Camera_isCameraFeature()
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param LookupTable an array of user-defined lookup table values (bytes)
         *  @param LookupTableSize the size of the user-defined lookup table
         *  @return success or error code
         */
        public unsafe
            SVSGigeApiReturn
          Gige_Camera_setLookupTable(int hCamera, sbyte* LookupTable, int LookupTableSize)
        {
            return Camera_setLookupTable(hCamera, LookupTable, LookupTableSize);

        }

        /** getLookupTable.
         *  The currently installed lookup table will be downloaded from the camera. The size of the
         *  reserved download space has to match the lookup table size (1024 for 10to8 or 4096 for 12to8).
         *
         *  @see Camera_isCameraFeature()
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param ProgrammedLookupTable an array for downloading the lookup table from camera
         *  @param LookupTableSize the size of the provided lookup table space
         *  @return success or error code
         */
        public unsafe
            SVSGigeApiReturn
          Gige_Camera_getLookupTable(int hCamera, sbyte* ProgrammedLookupTable, int LookupTableSize)
        {
            return Camera_getLookupTable(hCamera, ProgrammedLookupTable, LookupTableSize);
        }



        //------------------------------------------------------------------------------
        // 20 -  Special Control: IOMux configuration
        //------------------------------------------------------------------------------

        /** getMaxIOMuxIN.
         *  The maximal number of IN signals (signal sources) to the multiplexer will
         *  be returned that are currently available in the camera for connecting them
         *  to the multiplexer's OUT signals.
         *
         *  @see Camera_isCameraFeature()
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param MaxIOMuxINSignals the currently supported number of IN signals (signal sources)
         *  @return success or error code
         */

        public unsafe
        SVSGigeApiReturn
        Gige_Camera_getMaxIOMuxIN(int hCamera, int* MaxIOMuxINSignals)
        {
            SVSGigeApiReturn apiReturn;
            apiReturn = Camera_getMaxIOMuxIN(hCamera, MaxIOMuxINSignals);

            return apiReturn;
        }


        /** getMaxIOMuxOut.
         *  The maximal number of OUT signals (signal sinks) will be returned that
         *  are currently activated in the camera's IO multiplexer.
         *
         *  @see Camera_isCameraFeature()
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param MaxIOMuxOUTSignals the currently supported number of OUT signals (signal sinks)
         *  @return success or error code
         */

        public unsafe
        SVSGigeApiReturn
        Gige_Camera_getMaxIOMuxOUT(int hCamera, int* MaxIOMuxOUTSignals)
        {
            SVSGigeApiReturn apiReturn;
            apiReturn = Camera_getMaxIOMuxOUT(hCamera, MaxIOMuxOUTSignals);

            return apiReturn;

        }


        /** setIOAssignment.
         *  An OUT signal (signal sink) will get one or multiple IN signals (signal
         *  sources) assigned in a camera's multiplexer. In case of multiple signal
         *  sources (IN signals) those signals will be or'd for combining them to
         *  one 32-bit value that will subsequently be assigned to an OUT signal.
         *
         *  @see Camera_isCameraFeature()
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param IOMuxOUT the multiplexer's OUT signal (signal sink) to be configured
         *  @param SignalIOMuxIN the IN signal vector (signal sources) to be activated
         *  @return success or error code
         */

        public unsafe
        SVSGigeApiReturn
        Gige_Camera_setIOAssignment(int hCamera, SVGigE_IOMux_OUT IOMuxOUT,

                                        SVGigE_IOMux_IN SignalIOMuxIN)
        {
            SVSGigeApiReturn apiReturn;
            apiReturn = Camera_setIOAssignment(hCamera, IOMuxOUT, SignalIOMuxIN);

            return apiReturn;

        }


        /** getIOAssignment.
         *  Current assignment of IN signals (signal sources) to an OUT signal
         *  (signal sink) will be retrieved from a camera's multiplexer.
         *
         *  @see Camera_isCameraFeature()
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param IOMuxOUT the multiplexer's OUT signal (signal sink) to be queried
         *  @param ProgrammedIOMuxIN the IN signal vector (signal sources) connected to the OUT signal
         *  @return success or error code
         */


        public unsafe
        SVSGigeApiReturn
                Gige_Camera_getIOAssignment(int hCamera, SVGigE_IOMux_OUT IOMuxOUT,
                 uint* ProgrammedIOMuxIN)
        {
            SVSGigeApiReturn apiReturn;
            apiReturn = Camera_getIOAssignment(hCamera, IOMuxOUT, ProgrammedIOMuxIN);

            return apiReturn;

        }

        //------------------------------------------------------------------------------
        // 21 - Special Control: IO control
        //------------------------------------------------------------------------------

        /** setIOMuxIN.
         *  The complete vector of IN signals (source signals, max 32 bits) will be
         *  set in a camera's multiplexer in one go.
         *
         *  @see Camera_isCameraFeature()
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param VectorIOMuxIN the IN signal vector's new state to be assigned
         *  @return success or error code
         */

        public unsafe
        SVSGigeApiReturn
        Gige_Camera_setIOMuxIN(int hCamera, uint VectorIOMuxIN)
        {
            SVSGigeApiReturn apiReturn;


            apiReturn = Camera_setIOMuxIN(hCamera, VectorIOMuxIN);

            return apiReturn;

        }


        /** getIOMuxIN.
         *  The complete vector of IN signals (source signals, max 32 bits) will be
         *  read oout from a camera's multiplexer in one go.
         *
         *  @see Camera_isCameraFeature()
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param ProgrammedVectorIOMuxIN the IN signal vector's current state
         *  @return success or error code
         */


        public unsafe
        SVSGigeApiReturn
        Gige_Camera_getIOMuxIN(int hCamera, ref uint[] signalVector)
        {
            SVSGigeApiReturn apiReturn = SVSGigeApiReturn.SVGigE_ERROR;

            fixed (uint* ptr = (signalVector))
            {

                apiReturn = Camera_getIOMuxIN(hCamera, ptr);
            }
            return apiReturn;

        }

        /** setIO.
         *  A single IN signal (source signal, one out of max 32 bits) will be set.
         *
         *  @see Camera_isCameraFeature()
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param SignalIOMuxIN a particular signal from the IN signal vector
         *  @param SignalValue the signal value to be assigned to the IN signal
         *  @return success or error code
         */


        public unsafe
        SVSGigeApiReturn
        Gige_Camera_Camera_setIO(int hCamera, SVGigE_IOMux_IN SignalIOMuxIN,
                     SVGigE_IO_Signal SignalValue)
        {
            SVSGigeApiReturn apiReturn;
            apiReturn = Camera_setIO(hCamera, SignalIOMuxIN, SignalValue);

            return apiReturn;

        }


        /** getIO.
         *  A single IN signal (source signal, one out of max 32 bits) will be read.
         *
         *  @see Camera_isCameraFeature()
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param SignalIOMuxIN a particular signal from the IN signal vector
         *  @param the current value of the selected IN signal
         *  @return success or error code
         */


        public unsafe
        SVSGigeApiReturn
        Gige_Camera_getIO(int hCamera, SVGigE_IOMux_IN SignalIOMuxIN,
                     ref SVGigE_IO_Signal ProgrammedSignalValue)
        {
            SVSGigeApiReturn apiReturn;

            fixed (GigeApi.SVGigE_IO_Signal* signalValuePtr = &(ProgrammedSignalValue))
            {
                apiReturn = Camera_getIO(hCamera, SignalIOMuxIN, signalValuePtr);
            }

            return apiReturn;

        }


        // start ++++++++++++++++++++++++++++++++++++        

        /** setAcqLEDOverride.
         *  Override default LED mode by an alternative behavior:
         *  - blue:    waiting for trigger
         *  - cyan:    exposure
         *  - magenta: read-out
         *
         *  @see Camera_isCameraFeature()
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param isOverrideActive whether LED override will be activated or deactivated
         *  @return success or error code
         */
        public unsafe
          SVSGigeApiReturn
          Gige_Camera_setAcqLEDOverride(int hCamera, bool isOverrideActive)
        {
            return Camera_setAcqLEDOverride(hCamera, isOverrideActive);
        }


        /** getAcqLEDOverride.
         *  Check whether default LED mode was overridden by an alternative behavior:
         *  - blue:    waiting for trigger
         *  - cyan:    exposure
         *  - magenta: read-out
         *
         *  @see Camera_isCameraFeature()
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param isOverrideActive a flag indicating whether LED override is currently activated
         *  @return success or error code
         */
        public unsafe
          SVSGigeApiReturn
          Gige_Camera_getAcqLEDOverride(int hCamera, bool* isOverrideActive)
        {
            return Camera_getAcqLEDOverride(hCamera, isOverrideActive);
        }

        /** setLEDIntensity.
         *  The LED intensity will be controlled in the range 0..255 as follows:
         *  0   - dark
         *  255 - light
         *
         *  @see Camera_isCameraFeature()
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param LEDIntensity the new intensity (0..255=max) to be assigned to the LED
         *  @return success or error code
         */
        public unsafe
          SVSGigeApiReturn
          Gige_Camera_setLEDIntensity(int hCamera, int LEDIntensity)
        {
            return Camera_setLEDIntensity(hCamera, LEDIntensity);
        }

        /** getLEDIntensity.
         *  The LED intensity will be retrieved from camera with the following meaning:
         *  0   - dark
         *  255 - light
         *
         *  @see Camera_isCameraFeature()
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param ProgrammedLEDIntensity currently assigned LED intensity
         *  @return success or error code
         */
        public unsafe
          SVSGigeApiReturn
          Gige_Camera_getLEDIntensity(int hCamera, int* ProgrammedLEDIntensity)
        {
            return Camera_getLEDIntensity(hCamera, ProgrammedLEDIntensity);
        }

        //------------------------------------------------------------------------------
        // 24 - Special control: Serial communication
        //------------------------------------------------------------------------------

        /** setUARTBuffer.
         *  A block of data (max 512 bytes) will be sent to the camera's UART for
         *  transmitting it over the serial line to a receiver.
         *
         *  @see Camera_isCameraFeature()
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param Data a pointer to a block of data to be sent over the camera's UART
         *  @param the length of the data block (1..512)
         *  @return success or error code
         */
        public unsafe
          SVSGigeApiReturn
          Gige_Camera_setUARTBuffer(int hCamera, sbyte* Data, int DataLength)
        {
            return Camera_setUARTBuffer(hCamera, Data, DataLength);
        }

        /** getUARTBuffer.
         *  A block of data will be retrieved which has arrived in the camera's UART
         *  receiver buffer. If this function returns the maximal possible byte
         *  count then there might be more data available which should be retrieved
         *  by a subsequent call to this function.
         *
         *  @see Camera_isCameraFeature()
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param Data a pointer to a data buffer
         *  @param DataLengthReceived a pointer to a value for returning actual data read
         *  @param DataLengthMax the maximal data length to be read (1..512)
         *  @param Timeout a time period [s] after which the function returns if no data was received
         *  @return success or error code
         */
        public unsafe
          SVSGigeApiReturn
          Gige_Camera_getUARTBuffer(int hCamera, sbyte* Data, int* DataLengthReceived,
                               int DataLengthMax, float Timeout)
        {
            return Camera_getUARTBuffer(hCamera, Data, DataLengthReceived,
                                DataLengthMax, Timeout);
        }

        /** setUARTBaud.
         *  The baud rate of the camera's UART will be set to one out of a set of
         *  pre-defined baud rates. Alternatively, any baud rate can be provided
         *  as integer which would not have to comply with any pre-defined value.
         *
         *  @see Camera_isCameraFeature()
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param BaudRate the baud rate to be assigned to the UART
         *  @return success or error code
         */
        public unsafe
          SVSGigeApiReturn
          Gige_Camera_setUARTBaud(int hCamera, SVGigE_BaudRate BaudRate)
        {
            return Camera_setUARTBaud(hCamera, BaudRate);
        }

        /** getUARTBaud.
         *  The currently set baud rate in the camera's UART will be returned.
         *
         *  @see Camera_isCameraFeature()
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param ProgrammedBaudRate the UART's currently assigned baud rate
         *  @return success or error code
         */
        public unsafe
          SVSGigeApiReturn
          Gige_Camera_getUARTBaud(int hCamera, SVGigE_BaudRate* ProgrammedBaudRate)
        {
            return Camera_getUARTBaud(hCamera, ProgrammedBaudRate);
        }


        //------------------------------------------------------------------------------
        // 23 - Special control: Direct register and memory access
        //------------------------------------------------------------------------------


        /**
         * Set GigE camera register.
         * A register of a GigE camera will be directly written to
         *
         * @see CameraContainer_getCamera()
         * @param hCamera a camera handle received from CameraContainer_getCamera()
         * @param RegisterAddress a valid address of a GigE camera register
         * @param RegisterValue a value that has to be written to selected register
         * @param GigECameraAccessKey a valid key for directly accessing a GigE camera
         * @return success or error code
         */
        public unsafe
            SVSGigeApiReturn
            Gige_Camera_setGigECameraRegister(int hCamera,
            uint RegisterAddress,
            uint RegisterValue,
            uint GigECameraAccessKey)
        {
            return Camera_setGigECameraRegister(hCamera,
                RegisterAddress,
                RegisterValue,
                GigECameraAccessKey);
        }


        /**
         * Get GigE camera register.
         * A value from a GigE camera register will be directly read out
         *
         * @see CameraContainer_getCamera()
         * @param hCamera a camera handle received from CameraContainer_getCamera()
         * @param RegisterAddress a valid address of a GigE camera register
         * @param RegisterValue the current programmed value will be returned
         * @param GigECameraAccessKey a valid key for directly accessing a GigE camera
         * @return success or error code
         */
        public unsafe
            SVSGigeApiReturn
            Gige_Camera_getGigECameraRegister(int hCamera,
            uint RegisterAddress,
            ref uint ProgammedRegisterValue,
            uint GigECameraAccessKey)
        {

            SVSGigeApiReturn rval;
            fixed (uint* maskPtr = &ProgammedRegisterValue)
            {
                rval = Camera_getGigECameraRegister(hCamera,
                    RegisterAddress,
                    maskPtr,
                    GigECameraAccessKey);
            }
            return rval;
        }


        /** Write GigE camera memory.
         *  A block of data will be written to the memory of a SVS GigE camera
         *
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param MemoryAddress a valid memory address in a SVS GigE camera
         *  @param DataBlock a block of data that has to be written to selected memory
         *  @param DataLength the length of the specified DataBlock
         *  @param GigECameraAccessKey a valid key for directly accessing a GigE camera
         *  @return success or error code
         */
        public unsafe
            SVSGigeApiReturn
          Gige_Camera_writeGigECameraMemory(int hCamera,
                                       uint MemoryAddress,
                                       sbyte* DataBlock,
                                       uint DataLength,
                                       uint GigECameraAccessKey)
        {
            return Camera_writeGigECameraMemory(hCamera,
                                        MemoryAddress,
                                        DataBlock,
                                        DataLength,
                                        GigECameraAccessKey);
        }

        /** Read GigE camera memory.
         *  A block of data will be read from the memory of a SVS GigE camera
         *
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param MemoryAddress a valid memory address in a SVS GigE camera
         *  @param DataBlock an address where the data from selected memory will be written to
         *  @param DataLength the data length to be read from the camera's memory
         *  @param GigECameraAccessKey a valid key for directly accessing a GigE camera
         *  @return success or error code
         */
        public unsafe
            SVSGigeApiReturn
          Gige_Camera_readGigECameraMemory(int hCamera,
                                      uint MemoryAddress,
                                      sbyte* DataBlock,
                                      uint DataLength,
                                      uint GigECameraAccessKey)
        {
            return Camera_readGigECameraMemory(hCamera,
                                      MemoryAddress,
                                      DataBlock,
                                      DataLength,
                                      GigECameraAccessKey);
        }





        /** Force open connection to camera.
         *  A TCP/IP control channel will be established.
         *  The connection will be established independently whether the camera firmware
         *  matches a minimal build number or not. In case of a low build number the
         *  application may run into error conditions with SDK functions. Therefore
         *  this function can be used only by those applications that need to access
         *  cameras with an older firmware build. The application has to deal with all
         *  problem situations in this case. Usually an application needs to do direct
         *  register access in order to operate a camera with an older build number
         *
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param Timeout the time without traffic or heartbeat after which a camera drops a connection (default: 3.0 sec.)
         *                NOTE: Values between 0.0 to 0.5 sec. will be mapped to the default value (3.0 sec.)
         *  @return success or error code
         */
        public unsafe
        SVSGigeApiReturn
        Gige_Camera_forceOpenConnection(int hCamera, float Timeout)
        {
            return Camera_forceOpenConnection(hCamera, Timeout);
        }


        //------------------------------------------------------------------------------
        // 25 - General functions
        //------------------------------------------------------------------------------

        /**
         *  Estimate white balance.
         *  Current image will be investigated for a suitable white balance setting
         *
         *  @param BufferRGB a buffer with current RGB image
         *  @param BufferLength the length of the RGB buffer
         *  @param Red new value for red color
         *  @param Green new value for green color
         *  @param Blue new value for blue color
         *  @return success or error code
         */
        public unsafe
        SVSGigeApiReturn
        GigE_estimateWhiteBalance(sbyte* BufferRGB, int BufferLength, float* Red, float* Green, float* Blue)
        {
            return SVGigE_estimateWhiteBalance(BufferRGB, BufferLength, Red, Green, Blue);
        }

        /**
         *  Write image as a bitmap file to disk
         *  An image given by image data, geometry and type will be written to a
         *  specified location on disk.
         *
         *  @param Filename a path and filename for the bitmap file
         *  @param Data a pointer to image data
         *  @param SizeX the width of the image
         *  @param SizeY the height of the image
         *  @param PixelType either GVSP_PIX_MONO8 or GVSP_PIX_RGB24
         *  @return success or error code
         */
        public unsafe
        SVSGigeApiReturn
        GigE_writeImageToBitmapFile(sbyte* Filename, sbyte* Data, int SizeX, int SizeY, GVSP_PIXEL_TYPE PixelType)
        {
            return SVGigE_writeImageToBitmapFile(Filename, Data, SizeX, SizeY, PixelType);
        }

        //------------------------------------------------------------------------------
        // 26 - Special control: Persistent settings and recovery
        //------------------------------------------------------------------------------

        /**
         * Write EEPROM defaults.
         * The current settings will be made the EEPROM defaults that will be
         * restored on each camera start-up
         *
         * @see CameraContainer_getCamera()
         * @param hCamera a camera handle received from CameraContainer_getCamera()
         * @return success or error code
         */

        public unsafe
        SVSGigeApiReturn
        Gige_Camera_writeEEPROM(int hCamera)
        {
            return Camera_writeEEPROM(hCamera);
        }

        /**
         * Read EEPROM defaults.
         * The EEPROM content will be moved to the appropriate camera registers.
         * This operation will restore the camera settings that were active when
         * the EEPROM write function was performed
         *
         * @see CameraContainer_getCamera()
         * @param hCamera a camera handle received from CameraContainer_getCamera()
         * @return success or error code
         */

        public unsafe
        SVSGigeApiReturn
        Gige_Camera_readEEPROM(int hCamera)
        {
            return Camera_readEEPROM(hCamera);
        }

        /**
         * Restore factory defaults.
         * The camera's registers will be restored to the factory defaults and at
         * the same time those settings will be written as default to EEPROM
         *
         * @see CameraContainer_getCamera()
         * @param hCamera a camera handle received from CameraContainer_getCamera()
         * @return success or error code
         */

        public unsafe
        SVSGigeApiReturn
        Gige_Camera_restoreFactoryDefaults(int hCamera)
        {
            return Camera_restoreFactoryDefaults(hCamera);
        }


        /** Load settings from XML
          *  New camera settings will be loaded from a XML file.
          *  The  XML file content will be moved to the appropriate camera registers.
          *  In this operation the XML file will be used instead of the EEPROM. 
          *  
          *  @see CameraContainer_getCamera()
          *  @param hCamera a camera handle received from CameraContainer_getCamera()
          *  @param Filename a complete path and filename where to load the settings from
          *  @return success or error code
          */

        public unsafe
       SVSGigeApiReturn
       Gige_Camera_loadSettingsFromXml(int hCamera,
                                       string Filename)
        {
            return Camera_loadSettingsFromXml(hCamera,
                                                Filename);
        }

        /** Save settings to XML
         *  The current settings will be stored in a XML file 
         *  In this operation the XML file will be used instead of the EEPROM. 
         *
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param Filename a complete path and filename where to write the new settings.
         *  @return success or error code
         */

        public unsafe
            SVSGigeApiReturn
            Gige_Camera_SaveSettingsToXml(int hCamera,
             string Filename)
        {
            return Camera_SaveSettingsToXml(hCamera,
                  Filename);
        }

        //------------------------------------------------------------------------------
        // 26 - Diagnostics
        //------------------------------------------------------------------------------

        /**
         *  Error get message.
         *  If the provided function return code respresents an error condition then
         *  a message will be mapped to the return code which will explain it.
         *
         *  @param ReturnCode a valid function return code
         *  @return a string which will explain the return code
         */
        public unsafe
            sbyte*
            Gige_Error_getMessage(SVSGigeApiReturn ReturnCode)
        {
            return _Error_getMessage(ReturnCode);
        }

        /** Register for log messages.
         *  Log messages can be requested for various log levels:
         *  0 - logging off
         *  1 - CRITICAL errors that prevent from further operation
         *  2 - ERRORs that prevent from proper functioning
         *  3 - WARNINGs which usually do not affect proper work
         *  4 - INFO for listing camera communication (default)
         *  5 - DIAGNOSTICS for investigating image callbacks
         *  6 - DEBUG for receiving multiple parameters for image callbacks
         *  7 - DETAIL for receiving multiple signals for each image callback
         *
         *  Resulting log messages can be either written into a log file
         *  respectively they can be received by a callback and further
         *  processed by an application.
         *
         *  @see CameraContainer_getCamera()
         *  @param hCamera a camera handle received from CameraContainer_getCamera()
         *  @param LogLevel one of the above log levels
         *  @param LogFilename a filename where all log messages will be written to or NULL
         *  @param LogCallback a callback function that will receive all log messages or NULL
         *  @param MessageContext a context that will be returned to application with each callback or NULL
         *  @return success or error code
         */

        public unsafe
        SVSGigeApiReturn
           Gige_Camera_registerForLogMessages(int hCamera, int LogLevel, sbyte* LogFilename,
                                    LogMessageCallback LogCallback,
                                    void* MessageContext)
        {
            SVSGigeApiReturn rval;

            rval = Camera_registerForLogMessages(hCamera, LogLevel, LogFilename, LogCallback, MessageContext);

            return rval;
        }

        // ---------------------------------------------------------
        // 99 - Deprecated functions
        // ---------------------------------------------------------

        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
            SVSGigeApiReturn
            Camera_setLUTMode(int hCamera, LUT_MODE LUTMode);

        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
            SVSGigeApiReturn
            Camera_getLUTMode(int hCamera, LUT_MODE* ProgrammedLUTMode);

        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
            SVSGigeApiReturn Camera_createLUTwhiteBalance(int hCamera, float Red, float Green, float Blue);

        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
            SVSGigeApiReturn Camera_startAcquisitionCycle(int hCamera);

        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
            SVSGigeApiReturn
            Camera_stampTimestamp(int hCamera, int TimestampIndex);

        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
            SVSGigeApiReturn
            Camera_getTimestamp(int hCamera, int TimestampIndex, double* Timestamp);

        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
            SVSGigeApiReturn
            Camera_forceOpenConnection(int hCamera, float Timeout);

        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
            SVSGigeApiReturn
            Image_getImageGray(int hImage,
            byte* Buffer8bit,
            int BufferLength);
        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
        SVSGigeApiReturn
          Camera_setTapBalance(int hCamera, float TapBalance);

        [DllImport(SVGigE_DLL, CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe
        SVSGigeApiReturn
          Camera_getTapBalance(int hCamera, float* TapBalance);
    }// end class
}// end namespace
