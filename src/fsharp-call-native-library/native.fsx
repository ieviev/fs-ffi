

open System.Runtime.InteropServices

// example linux x11 binding with structs
module xlib =
    [<Struct ; StructLayout(LayoutKind.Sequential); >]
    type ClassHintsReturn =
        {
            res_name : string
            res_class : string
        }

    [<DllImport("X11.so.6")>]
    extern unit XGetWMName(nativeint display, nativeint window, string& windowname);

// example native F# library binding from src/fsharp-native-shared-library

//name gets converted to lib<name>.so, <name>.dll etc on each platform
[<DllImport("fsharplibrary")>]
extern unit write_hello()

write_hello()

[<DllImport("fsharplibrary")>]
extern int32 add(int32 a, int32 b)

let result = add(1,2)

stdout.WriteLine $"1 + 2 is {result} // a + b + b hardcoded in /src/fsharp-native-shared-library/Library.fs"

[<DllImport("fsharplibrary")>]
extern int32 write_line(nativeint pstr)


let pointer_to_str =
    Marshal.StringToHGlobalAuto("this string is allocated in dotnet")

write_line(pointer_to_str)

let pstr_to_dotnet_string (pstr:nativeint) =
    Marshal.PtrToStringAuto(pstr)

// [<DllImport( "user32.dll", CallingConvention = CallingConvention.Cdecl )>]
// extern void ShowCursor(bool show)

