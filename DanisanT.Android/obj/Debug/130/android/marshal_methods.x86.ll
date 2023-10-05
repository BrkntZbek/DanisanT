; ModuleID = 'obj\Debug\130\android\marshal_methods.x86.ll'
source_filename = "obj\Debug\130\android\marshal_methods.x86.ll"
target datalayout = "e-m:e-p:32:32-p270:32:32-p271:32:32-p272:64:64-f64:32:64-f80:32-n8:16:32-S128"
target triple = "i686-unknown-linux-android"


%struct.MonoImage = type opaque

%struct.MonoClass = type opaque

%struct.MarshalMethodsManagedClass = type {
	i32,; uint32_t token
	%struct.MonoClass*; MonoClass* klass
}

%struct.MarshalMethodName = type {
	i64,; uint64_t id
	i8*; char* name
}

%class._JNIEnv = type opaque

%class._jobject = type {
	i8; uint8_t b
}

%class._jclass = type {
	i8; uint8_t b
}

%class._jstring = type {
	i8; uint8_t b
}

%class._jthrowable = type {
	i8; uint8_t b
}

%class._jarray = type {
	i8; uint8_t b
}

%class._jobjectArray = type {
	i8; uint8_t b
}

%class._jbooleanArray = type {
	i8; uint8_t b
}

%class._jbyteArray = type {
	i8; uint8_t b
}

%class._jcharArray = type {
	i8; uint8_t b
}

%class._jshortArray = type {
	i8; uint8_t b
}

%class._jintArray = type {
	i8; uint8_t b
}

%class._jlongArray = type {
	i8; uint8_t b
}

%class._jfloatArray = type {
	i8; uint8_t b
}

%class._jdoubleArray = type {
	i8; uint8_t b
}

; assembly_image_cache
@assembly_image_cache = local_unnamed_addr global [0 x %struct.MonoImage*] zeroinitializer, align 4
; Each entry maps hash of an assembly name to an index into the `assembly_image_cache` array
@assembly_image_cache_hashes = local_unnamed_addr constant [204 x i32] [
	i32 32687329, ; 0: Xamarin.AndroidX.Lifecycle.Runtime => 0x1f2c4e1 => 54
	i32 34715100, ; 1: Xamarin.Google.Guava.ListenableFuture.dll => 0x211b5dc => 83
	i32 57263871, ; 2: Xamarin.Forms.Core.dll => 0x369c6ff => 78
	i32 101534019, ; 3: Xamarin.AndroidX.SlidingPaneLayout => 0x60d4943 => 68
	i32 120558881, ; 4: Xamarin.AndroidX.SlidingPaneLayout.dll => 0x72f9521 => 68
	i32 165246403, ; 5: Xamarin.AndroidX.Collection.dll => 0x9d975c3 => 35
	i32 182336117, ; 6: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0xade3a75 => 69
	i32 209399409, ; 7: Xamarin.AndroidX.Browser.dll => 0xc7b2e71 => 33
	i32 220171995, ; 8: System.Diagnostics.Debug => 0xd1f8edb => 97
	i32 230216969, ; 9: Xamarin.AndroidX.Legacy.Support.Core.Utils.dll => 0xdb8d509 => 49
	i32 230752869, ; 10: Microsoft.CSharp.dll => 0xdc10265 => 9
	i32 232815796, ; 11: System.Web.Services => 0xde07cb4 => 91
	i32 261689757, ; 12: Xamarin.AndroidX.ConstraintLayout.dll => 0xf99119d => 38
	i32 278686392, ; 13: Xamarin.AndroidX.Lifecycle.LiveData.dll => 0x109c6ab8 => 53
	i32 280482487, ; 14: Xamarin.AndroidX.Interpolator => 0x10b7d2b7 => 47
	i32 318968648, ; 15: Xamarin.AndroidX.Activity.dll => 0x13031348 => 25
	i32 321597661, ; 16: System.Numerics => 0x132b30dd => 19
	i32 342366114, ; 17: Xamarin.AndroidX.Lifecycle.Common => 0x146817a2 => 51
	i32 441335492, ; 18: Xamarin.AndroidX.ConstraintLayout.Core => 0x1a4e3ec4 => 37
	i32 442521989, ; 19: Xamarin.Essentials => 0x1a605985 => 77
	i32 442565967, ; 20: System.Collections => 0x1a61054f => 95
	i32 450948140, ; 21: Xamarin.AndroidX.Fragment.dll => 0x1ae0ec2c => 46
	i32 465846621, ; 22: mscorlib => 0x1bc4415d => 12
	i32 469710990, ; 23: System.dll => 0x1bff388e => 18
	i32 476646585, ; 24: Xamarin.AndroidX.Interpolator.dll => 0x1c690cb9 => 47
	i32 486930444, ; 25: Xamarin.AndroidX.LocalBroadcastManager.dll => 0x1d05f80c => 58
	i32 498788369, ; 26: System.ObjectModel => 0x1dbae811 => 96
	i32 526420162, ; 27: System.Transactions.dll => 0x1f6088c2 => 85
	i32 530272170, ; 28: System.Linq.Queryable => 0x1f9b4faa => 2
	i32 545304856, ; 29: System.Runtime.Extensions => 0x2080b118 => 98
	i32 605376203, ; 30: System.IO.Compression.FileSystem => 0x24154ecb => 89
	i32 627609679, ; 31: Xamarin.AndroidX.CustomView => 0x2568904f => 42
	i32 663517072, ; 32: Xamarin.AndroidX.VersionedParcelable => 0x278c7790 => 74
	i32 666292255, ; 33: Xamarin.AndroidX.Arch.Core.Common.dll => 0x27b6d01f => 30
	i32 690569205, ; 34: System.Xml.Linq.dll => 0x29293ff5 => 24
	i32 775507847, ; 35: System.IO.Compression => 0x2e394f87 => 88
	i32 809851609, ; 36: System.Drawing.Common.dll => 0x30455ad9 => 87
	i32 843511501, ; 37: Xamarin.AndroidX.Print => 0x3246f6cd => 65
	i32 880660139, ; 38: Remotion.Linq => 0x347dceab => 14
	i32 902159924, ; 39: Rg.Plugins.Popup => 0x35c5de34 => 15
	i32 928116545, ; 40: Xamarin.Google.Guava.ListenableFuture => 0x3751ef41 => 83
	i32 967690846, ; 41: Xamarin.AndroidX.Lifecycle.Common.dll => 0x39adca5e => 51
	i32 969074747, ; 42: DanisanT => 0x39c2e83b => 6
	i32 974778368, ; 43: FormsViewGroup.dll => 0x3a19f000 => 7
	i32 992768348, ; 44: System.Collections.dll => 0x3b2c715c => 95
	i32 1012816738, ; 45: Xamarin.AndroidX.SavedState.dll => 0x3c5e5b62 => 67
	i32 1034459858, ; 46: Remotion.Linq.dll => 0x3da89ad2 => 14
	i32 1035644815, ; 47: Xamarin.AndroidX.AppCompat => 0x3dbaaf8f => 29
	i32 1042160112, ; 48: Xamarin.Forms.Platform.dll => 0x3e1e19f0 => 80
	i32 1044663988, ; 49: System.Linq.Expressions.dll => 0x3e444eb4 => 93
	i32 1052210849, ; 50: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x3eb776a1 => 55
	i32 1098259244, ; 51: System => 0x41761b2c => 18
	i32 1175144683, ; 52: Xamarin.AndroidX.VectorDrawable.Animated => 0x460b48eb => 72
	i32 1178241025, ; 53: Xamarin.AndroidX.Navigation.Runtime.dll => 0x463a8801 => 62
	i32 1204270330, ; 54: Xamarin.AndroidX.Arch.Core.Common => 0x47c7b4fa => 30
	i32 1241264201, ; 55: Realm.dll => 0x49fc3049 => 13
	i32 1267360935, ; 56: Xamarin.AndroidX.VectorDrawable => 0x4b8a64a7 => 73
	i32 1293217323, ; 57: Xamarin.AndroidX.DrawerLayout.dll => 0x4d14ee2b => 44
	i32 1324164729, ; 58: System.Linq => 0x4eed2679 => 99
	i32 1365406463, ; 59: System.ServiceModel.Internals.dll => 0x516272ff => 92
	i32 1376866003, ; 60: Xamarin.AndroidX.SavedState => 0x52114ed3 => 67
	i32 1391893274, ; 61: MongoDB.Bson.dll => 0x52f69b1a => 10
	i32 1395857551, ; 62: Xamarin.AndroidX.Media.dll => 0x5333188f => 59
	i32 1406073936, ; 63: Xamarin.AndroidX.CoordinatorLayout => 0x53cefc50 => 39
	i32 1411638395, ; 64: System.Runtime.CompilerServices.Unsafe => 0x5423e47b => 21
	i32 1457743152, ; 65: System.Runtime.Extensions.dll => 0x56e36530 => 98
	i32 1460219004, ; 66: Xamarin.Forms.Xaml => 0x57092c7c => 81
	i32 1462112819, ; 67: System.IO.Compression.dll => 0x57261233 => 88
	i32 1469204771, ; 68: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x57924923 => 28
	i32 1550322496, ; 69: System.Reflection.Extensions.dll => 0x5c680b40 => 3
	i32 1582372066, ; 70: Xamarin.AndroidX.DocumentFile.dll => 0x5e5114e2 => 43
	i32 1592978981, ; 71: System.Runtime.Serialization.dll => 0x5ef2ee25 => 5
	i32 1622152042, ; 72: Xamarin.AndroidX.Loader.dll => 0x60b0136a => 57
	i32 1624863272, ; 73: Xamarin.AndroidX.ViewPager2 => 0x60d97228 => 76
	i32 1636350590, ; 74: Xamarin.AndroidX.CursorAdapter => 0x6188ba7e => 41
	i32 1639515021, ; 75: System.Net.Http.dll => 0x61b9038d => 4
	i32 1657153582, ; 76: System.Runtime => 0x62c6282e => 22
	i32 1658241508, ; 77: Xamarin.AndroidX.Tracing.Tracing.dll => 0x62d6c1e4 => 70
	i32 1658251792, ; 78: Xamarin.Google.Android.Material.dll => 0x62d6ea10 => 82
	i32 1670060433, ; 79: Xamarin.AndroidX.ConstraintLayout => 0x638b1991 => 38
	i32 1701541528, ; 80: System.Diagnostics.Debug.dll => 0x656b7698 => 97
	i32 1726116996, ; 81: System.Reflection.dll => 0x66e27484 => 94
	i32 1729485958, ; 82: Xamarin.AndroidX.CardView.dll => 0x6715dc86 => 34
	i32 1765942094, ; 83: System.Reflection.Extensions => 0x6942234e => 3
	i32 1766324549, ; 84: Xamarin.AndroidX.SwipeRefreshLayout => 0x6947f945 => 69
	i32 1776026572, ; 85: System.Core.dll => 0x69dc03cc => 17
	i32 1788241197, ; 86: Xamarin.AndroidX.Fragment => 0x6a96652d => 46
	i32 1808609942, ; 87: Xamarin.AndroidX.Loader => 0x6bcd3296 => 57
	i32 1813201214, ; 88: Xamarin.Google.Android.Material => 0x6c13413e => 82
	i32 1818569960, ; 89: Xamarin.AndroidX.Navigation.UI.dll => 0x6c652ce8 => 63
	i32 1858542181, ; 90: System.Linq.Expressions => 0x6ec71a65 => 93
	i32 1867746548, ; 91: Xamarin.Essentials.dll => 0x6f538cf4 => 77
	i32 1878053835, ; 92: Xamarin.Forms.Xaml.dll => 0x6ff0d3cb => 81
	i32 1885316902, ; 93: Xamarin.AndroidX.Arch.Core.Runtime.dll => 0x705fa726 => 31
	i32 1919157823, ; 94: Xamarin.AndroidX.MultiDex.dll => 0x7264063f => 60
	i32 2011961780, ; 95: System.Buffers.dll => 0x77ec19b4 => 16
	i32 2019465201, ; 96: Xamarin.AndroidX.Lifecycle.ViewModel => 0x785e97f1 => 55
	i32 2055257422, ; 97: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x7a80bd4e => 52
	i32 2079903147, ; 98: System.Runtime.dll => 0x7bf8cdab => 22
	i32 2090596640, ; 99: System.Numerics.Vectors => 0x7c9bf920 => 20
	i32 2097448633, ; 100: Xamarin.AndroidX.Legacy.Support.Core.UI => 0x7d0486b9 => 48
	i32 2126786730, ; 101: Xamarin.Forms.Platform.Android => 0x7ec430aa => 79
	i32 2193016926, ; 102: System.ObjectModel.dll => 0x82b6c85e => 96
	i32 2201231467, ; 103: System.Net.Http => 0x8334206b => 4
	i32 2217644978, ; 104: Xamarin.AndroidX.VectorDrawable.Animated.dll => 0x842e93b2 => 72
	i32 2244775296, ; 105: Xamarin.AndroidX.LocalBroadcastManager => 0x85cc8d80 => 58
	i32 2256548716, ; 106: Xamarin.AndroidX.MultiDex => 0x8680336c => 60
	i32 2261435625, ; 107: Xamarin.AndroidX.Legacy.Support.V4.dll => 0x86cac4e9 => 50
	i32 2279755925, ; 108: Xamarin.AndroidX.RecyclerView.dll => 0x87e25095 => 66
	i32 2315684594, ; 109: Xamarin.AndroidX.Annotation.dll => 0x8a068af2 => 26
	i32 2409053734, ; 110: Xamarin.AndroidX.Preference.dll => 0x8f973e26 => 64
	i32 2465532216, ; 111: Xamarin.AndroidX.ConstraintLayout.Core.dll => 0x92f50938 => 37
	i32 2468915515, ; 112: DanisanT.Android => 0x9328a93b => 0
	i32 2471841756, ; 113: netstandard.dll => 0x93554fdc => 1
	i32 2475788418, ; 114: Java.Interop.dll => 0x93918882 => 8
	i32 2501346920, ; 115: System.Data.DataSetExtensions => 0x95178668 => 86
	i32 2505896520, ; 116: Xamarin.AndroidX.Lifecycle.Runtime.dll => 0x955cf248 => 54
	i32 2562349572, ; 117: Microsoft.CSharp => 0x98ba5a04 => 9
	i32 2581819634, ; 118: Xamarin.AndroidX.VectorDrawable.dll => 0x99e370f2 => 73
	i32 2620871830, ; 119: Xamarin.AndroidX.CursorAdapter.dll => 0x9c375496 => 41
	i32 2624644809, ; 120: Xamarin.AndroidX.DynamicAnimation => 0x9c70e6c9 => 45
	i32 2633051222, ; 121: Xamarin.AndroidX.Lifecycle.LiveData => 0x9cf12c56 => 53
	i32 2701096212, ; 122: Xamarin.AndroidX.Tracing.Tracing => 0xa0ff7514 => 70
	i32 2732626843, ; 123: Xamarin.AndroidX.Activity => 0xa2e0939b => 25
	i32 2737747696, ; 124: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0xa32eb6f0 => 28
	i32 2763363513, ; 125: DanisanT.dll => 0xa4b594b9 => 6
	i32 2766581644, ; 126: Xamarin.Forms.Core => 0xa4e6af8c => 78
	i32 2778768386, ; 127: Xamarin.AndroidX.ViewPager.dll => 0xa5a0a402 => 75
	i32 2810250172, ; 128: Xamarin.AndroidX.CoordinatorLayout.dll => 0xa78103bc => 39
	i32 2812738563, ; 129: DanisanT.Android.dll => 0xa7a6fc03 => 0
	i32 2819470561, ; 130: System.Xml.dll => 0xa80db4e1 => 23
	i32 2853208004, ; 131: Xamarin.AndroidX.ViewPager => 0xaa107fc4 => 75
	i32 2855708567, ; 132: Xamarin.AndroidX.Transition => 0xaa36a797 => 71
	i32 2860834411, ; 133: Realm => 0xaa84de6b => 13
	i32 2861816565, ; 134: Rg.Plugins.Popup.dll => 0xaa93daf5 => 15
	i32 2901442782, ; 135: System.Reflection => 0xacf080de => 94
	i32 2903344695, ; 136: System.ComponentModel.Composition => 0xad0d8637 => 90
	i32 2905242038, ; 137: mscorlib.dll => 0xad2a79b6 => 12
	i32 2916838712, ; 138: Xamarin.AndroidX.ViewPager2.dll => 0xaddb6d38 => 76
	i32 2919462931, ; 139: System.Numerics.Vectors.dll => 0xae037813 => 20
	i32 2921128767, ; 140: Xamarin.AndroidX.Annotation.Experimental.dll => 0xae1ce33f => 27
	i32 2978675010, ; 141: Xamarin.AndroidX.DrawerLayout => 0xb18af942 => 44
	i32 3024354802, ; 142: Xamarin.AndroidX.Legacy.Support.Core.Utils => 0xb443fdf2 => 49
	i32 3044182254, ; 143: FormsViewGroup => 0xb57288ee => 7
	i32 3057625584, ; 144: Xamarin.AndroidX.Navigation.Common => 0xb63fa9f0 => 61
	i32 3111772706, ; 145: System.Runtime.Serialization => 0xb979e222 => 5
	i32 3204380047, ; 146: System.Data.dll => 0xbefef58f => 84
	i32 3211777861, ; 147: Xamarin.AndroidX.DocumentFile => 0xbf6fd745 => 43
	i32 3220365878, ; 148: System.Threading => 0xbff2e236 => 100
	i32 3247949154, ; 149: Mono.Security => 0xc197c562 => 101
	i32 3258312781, ; 150: Xamarin.AndroidX.CardView => 0xc235e84d => 34
	i32 3258876633, ; 151: MongoDB.Bson => 0xc23e82d9 => 10
	i32 3265493905, ; 152: System.Linq.Queryable.dll => 0xc2a37b91 => 2
	i32 3267021929, ; 153: Xamarin.AndroidX.AsyncLayoutInflater => 0xc2bacc69 => 32
	i32 3317135071, ; 154: Xamarin.AndroidX.CustomView.dll => 0xc5b776df => 42
	i32 3317144872, ; 155: System.Data => 0xc5b79d28 => 84
	i32 3340431453, ; 156: Xamarin.AndroidX.Arch.Core.Runtime => 0xc71af05d => 31
	i32 3346324047, ; 157: Xamarin.AndroidX.Navigation.Runtime => 0xc774da4f => 62
	i32 3353484488, ; 158: Xamarin.AndroidX.Legacy.Support.Core.UI.dll => 0xc7e21cc8 => 48
	i32 3362522851, ; 159: Xamarin.AndroidX.Core => 0xc86c06e3 => 40
	i32 3366347497, ; 160: Java.Interop => 0xc8a662e9 => 8
	i32 3374999561, ; 161: Xamarin.AndroidX.RecyclerView => 0xc92a6809 => 66
	i32 3395150330, ; 162: System.Runtime.CompilerServices.Unsafe.dll => 0xca5de1fa => 21
	i32 3404865022, ; 163: System.ServiceModel.Internals => 0xcaf21dfe => 92
	i32 3429136800, ; 164: System.Xml => 0xcc6479a0 => 23
	i32 3430777524, ; 165: netstandard => 0xcc7d82b4 => 1
	i32 3441283291, ; 166: Xamarin.AndroidX.DynamicAnimation.dll => 0xcd1dd0db => 45
	i32 3476120550, ; 167: Mono.Android => 0xcf3163e6 => 11
	i32 3486566296, ; 168: System.Transactions => 0xcfd0c798 => 85
	i32 3493954962, ; 169: Xamarin.AndroidX.Concurrent.Futures.dll => 0xd0418592 => 36
	i32 3501239056, ; 170: Xamarin.AndroidX.AsyncLayoutInflater.dll => 0xd0b0ab10 => 32
	i32 3509114376, ; 171: System.Xml.Linq => 0xd128d608 => 24
	i32 3536029504, ; 172: Xamarin.Forms.Platform.Android.dll => 0xd2c38740 => 79
	i32 3567349600, ; 173: System.ComponentModel.Composition.dll => 0xd4a16f60 => 90
	i32 3608519521, ; 174: System.Linq.dll => 0xd715a361 => 99
	i32 3618140916, ; 175: Xamarin.AndroidX.Preference => 0xd7a872f4 => 64
	i32 3627220390, ; 176: Xamarin.AndroidX.Print.dll => 0xd832fda6 => 65
	i32 3632359727, ; 177: Xamarin.Forms.Platform => 0xd881692f => 80
	i32 3633644679, ; 178: Xamarin.AndroidX.Annotation.Experimental => 0xd8950487 => 27
	i32 3641597786, ; 179: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0xd90e5f5a => 52
	i32 3672681054, ; 180: Mono.Android.dll => 0xdae8aa5e => 11
	i32 3676310014, ; 181: System.Web.Services.dll => 0xdb2009fe => 91
	i32 3682565725, ; 182: Xamarin.AndroidX.Browser => 0xdb7f7e5d => 33
	i32 3684561358, ; 183: Xamarin.AndroidX.Concurrent.Futures => 0xdb9df1ce => 36
	i32 3689375977, ; 184: System.Drawing.Common => 0xdbe768e9 => 87
	i32 3718780102, ; 185: Xamarin.AndroidX.Annotation => 0xdda814c6 => 26
	i32 3724971120, ; 186: Xamarin.AndroidX.Navigation.Common.dll => 0xde068c70 => 61
	i32 3758932259, ; 187: Xamarin.AndroidX.Legacy.Support.V4 => 0xe00cc123 => 50
	i32 3786282454, ; 188: Xamarin.AndroidX.Collection => 0xe1ae15d6 => 35
	i32 3822602673, ; 189: Xamarin.AndroidX.Media => 0xe3d849b1 => 59
	i32 3829621856, ; 190: System.Numerics.dll => 0xe4436460 => 19
	i32 3885922214, ; 191: Xamarin.AndroidX.Transition.dll => 0xe79e77a6 => 71
	i32 3896760992, ; 192: Xamarin.AndroidX.Core.dll => 0xe843daa0 => 40
	i32 3920810846, ; 193: System.IO.Compression.FileSystem.dll => 0xe9b2d35e => 89
	i32 3921031405, ; 194: Xamarin.AndroidX.VersionedParcelable.dll => 0xe9b630ed => 74
	i32 3931092270, ; 195: Xamarin.AndroidX.Navigation.UI => 0xea4fb52e => 63
	i32 3945713374, ; 196: System.Data.DataSetExtensions.dll => 0xeb2ecede => 86
	i32 3955647286, ; 197: Xamarin.AndroidX.AppCompat.dll => 0xebc66336 => 29
	i32 4073602200, ; 198: System.Threading.dll => 0xf2ce3c98 => 100
	i32 4105002889, ; 199: Mono.Security.dll => 0xf4ad5f89 => 101
	i32 4151237749, ; 200: System.Core => 0xf76edc75 => 17
	i32 4182413190, ; 201: Xamarin.AndroidX.Lifecycle.ViewModelSavedState.dll => 0xf94a8f86 => 56
	i32 4260525087, ; 202: System.Buffers => 0xfdf2741f => 16
	i32 4292120959 ; 203: Xamarin.AndroidX.Lifecycle.ViewModelSavedState => 0xffd4917f => 56
], align 4
@assembly_image_cache_indices = local_unnamed_addr constant [204 x i32] [
	i32 54, i32 83, i32 78, i32 68, i32 68, i32 35, i32 69, i32 33, ; 0..7
	i32 97, i32 49, i32 9, i32 91, i32 38, i32 53, i32 47, i32 25, ; 8..15
	i32 19, i32 51, i32 37, i32 77, i32 95, i32 46, i32 12, i32 18, ; 16..23
	i32 47, i32 58, i32 96, i32 85, i32 2, i32 98, i32 89, i32 42, ; 24..31
	i32 74, i32 30, i32 24, i32 88, i32 87, i32 65, i32 14, i32 15, ; 32..39
	i32 83, i32 51, i32 6, i32 7, i32 95, i32 67, i32 14, i32 29, ; 40..47
	i32 80, i32 93, i32 55, i32 18, i32 72, i32 62, i32 30, i32 13, ; 48..55
	i32 73, i32 44, i32 99, i32 92, i32 67, i32 10, i32 59, i32 39, ; 56..63
	i32 21, i32 98, i32 81, i32 88, i32 28, i32 3, i32 43, i32 5, ; 64..71
	i32 57, i32 76, i32 41, i32 4, i32 22, i32 70, i32 82, i32 38, ; 72..79
	i32 97, i32 94, i32 34, i32 3, i32 69, i32 17, i32 46, i32 57, ; 80..87
	i32 82, i32 63, i32 93, i32 77, i32 81, i32 31, i32 60, i32 16, ; 88..95
	i32 55, i32 52, i32 22, i32 20, i32 48, i32 79, i32 96, i32 4, ; 96..103
	i32 72, i32 58, i32 60, i32 50, i32 66, i32 26, i32 64, i32 37, ; 104..111
	i32 0, i32 1, i32 8, i32 86, i32 54, i32 9, i32 73, i32 41, ; 112..119
	i32 45, i32 53, i32 70, i32 25, i32 28, i32 6, i32 78, i32 75, ; 120..127
	i32 39, i32 0, i32 23, i32 75, i32 71, i32 13, i32 15, i32 94, ; 128..135
	i32 90, i32 12, i32 76, i32 20, i32 27, i32 44, i32 49, i32 7, ; 136..143
	i32 61, i32 5, i32 84, i32 43, i32 100, i32 101, i32 34, i32 10, ; 144..151
	i32 2, i32 32, i32 42, i32 84, i32 31, i32 62, i32 48, i32 40, ; 152..159
	i32 8, i32 66, i32 21, i32 92, i32 23, i32 1, i32 45, i32 11, ; 160..167
	i32 85, i32 36, i32 32, i32 24, i32 79, i32 90, i32 99, i32 64, ; 168..175
	i32 65, i32 80, i32 27, i32 52, i32 11, i32 91, i32 33, i32 36, ; 176..183
	i32 87, i32 26, i32 61, i32 50, i32 35, i32 59, i32 19, i32 71, ; 184..191
	i32 40, i32 89, i32 74, i32 63, i32 86, i32 29, i32 100, i32 101, ; 192..199
	i32 17, i32 56, i32 16, i32 56 ; 200..203
], align 4

@marshal_methods_number_of_classes = local_unnamed_addr constant i32 0, align 4

; marshal_methods_class_cache
@marshal_methods_class_cache = global [0 x %struct.MarshalMethodsManagedClass] [
], align 4; end of 'marshal_methods_class_cache' array


@get_function_pointer = internal unnamed_addr global void (i32, i32, i32, i8**)* null, align 4

; Function attributes: "frame-pointer"="none" "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" "stackrealign" "target-cpu"="i686" "target-features"="+cx8,+mmx,+sse,+sse2,+sse3,+ssse3,+x87" "tune-cpu"="generic" uwtable willreturn writeonly
define void @xamarin_app_init (void (i32, i32, i32, i8**)* %fn) local_unnamed_addr #0
{
	store void (i32, i32, i32, i8**)* %fn, void (i32, i32, i32, i8**)** @get_function_pointer, align 4
	ret void
}

; Names of classes in which marshal methods reside
@mm_class_names = local_unnamed_addr constant [0 x i8*] zeroinitializer, align 4
@__MarshalMethodName_name.0 = internal constant [1 x i8] c"\00", align 1

; mm_method_names
@mm_method_names = local_unnamed_addr constant [1 x %struct.MarshalMethodName] [
	; 0
	%struct.MarshalMethodName {
		i64 0, ; id 0x0; name: 
		i8* getelementptr inbounds ([1 x i8], [1 x i8]* @__MarshalMethodName_name.0, i32 0, i32 0); name
	}
], align 8; end of 'mm_method_names' array


attributes #0 = { "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable willreturn writeonly "frame-pointer"="none" "target-cpu"="i686" "target-features"="+cx8,+mmx,+sse,+sse2,+sse3,+ssse3,+x87" "tune-cpu"="generic" "stackrealign" }
attributes #1 = { "min-legal-vector-width"="0" mustprogress "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable "frame-pointer"="none" "target-cpu"="i686" "target-features"="+cx8,+mmx,+sse,+sse2,+sse3,+ssse3,+x87" "tune-cpu"="generic" "stackrealign" }
attributes #2 = { nounwind }

!llvm.module.flags = !{!0, !1, !2}
!llvm.ident = !{!3}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!2 = !{i32 1, !"NumRegisterParameters", i32 0}
!3 = !{!"Xamarin.Android remotes/origin/d17-5 @ 797e2e13d1706ace607da43703769c5a55c4de60"}
!llvm.linker.options = !{}
