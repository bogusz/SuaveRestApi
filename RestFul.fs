namespace SuaveRestApi.Rest
open Newtonsoft.Json
open Newtonsoft.Json.Serialization
open Suave.Http
open Suave.Http.Successful
open Suave.Http.Applicatives

[<AutoOpen>]
module RestFul =

    let JSON v =     
        let jsonSerializerSettings = new JsonSerializerSettings()
        jsonSerializerSettings.ContractResolver <- new CamelCasePropertyNamesContractResolver()    
        JsonConvert.SerializeObject(v, jsonSerializerSettings) 
        |> OK  
        >>= Writers.setMimeType "application/json; charset=utf-8"

    type RestResource<'a> = {
        GetAll : unit -> 'a seq
    }

    let rest resourceName resource =        
        let resourcePath = "/" + resourceName
        let getAll = warbler (fun _ -> resource.GetAll () |> JSON)
        path resourcePath >>= GET >>= getAll

