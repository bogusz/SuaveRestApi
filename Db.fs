namespace SuaveRestApi.Db

open System.Collections.Generic

type Person = {
  Id : int
  Name : string
  Age : int
  Email : string
}

module Db =

    let private peopleStorage = new Dictionary<int, Person>()
    
    peopleStorage.Add(1, {
        Id = 1
        Name = "Scott Hanselman"
        Age = 35
        Email = "scott@hanselman.com"
    })

    peopleStorage.Add(2, {
        Id = 1
        Name = "Udi Dahan"
        Age = 35
        Email = "udi@dahan.com"
    })

    let getPeople () = 
        peopleStorage.Values |> Seq.map (fun p -> p)
