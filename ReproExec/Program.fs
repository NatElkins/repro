// Learn more about F# at http://fsharp.org

open System
open System.IO

let private getEmbeddedStringFromFile (resourceName:string) =
    let assembly = System.Reflection.Assembly.GetExecutingAssembly()
    printfn "Assembly: %A" assembly
    let rns = assembly.GetManifestResourceNames()
    printfn "Resource Names: %A" rns
    let rn = assembly.GetManifestResourceNames() |> Seq.find (fun n -> n.EndsWith resourceName)
    use s = assembly.GetManifestResourceStream rn
    use sr = new StreamReader(s)
    sr.ReadToEnd()

let private resource = getEmbeddedStringFromFile "test.txt"

[<EntryPoint>]
let main argv =
    ReproLib.Say.hello "FCSWatch!!"
    ReproLib.Say.hello resource
    printfn "Hello World from Nat!!"
    0 // return an integer exit code
