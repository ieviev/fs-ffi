module NativeLibrary

open System.Runtime.InteropServices
open System

[<UnmanagedCallersOnly(EntryPoint = "add")>]
let Add (a: int) (b: int) : int =
    a + b + b

[<UnmanagedCallersOnly(EntryPoint = "write_line")>]
let WriteLine (pString: nativeint) : int =
    try
        let str = Marshal.PtrToStringUTF8(pString)
        Console.WriteLine("TEST")
        Console.WriteLine(str)
        0
    with
    | _ -> -1


[<UnmanagedCallersOnly(EntryPoint = "write_hello")>]
let WriteHello () : int =
    try
        Console.WriteLine("hello")
        0
    with
    | _ -> -1

