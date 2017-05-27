namespace Easysoft
open Microsoft.FSharp.Quotations.Patterns
open Microsoft.FSharp.Quotations

[<AutoOpen>]
module Utility=
    let (!!) quotation =
        match quotation with
        | PropertyGet (_,propertyInfo,_) -> propertyInfo
        | _ -> raise(failwith "Property does not exist")


