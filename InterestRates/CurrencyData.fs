open System
open System.IO
open System.Runtime.Serialization

type TimedRate =
    { date : DateTime ;
      rate : float }

type HistoricData = Array of TimedRate array

let saveHistoricData (data : HistoricData) (stream : System.IO.Stream) =
    let serializer = DataContractSerializer(typeof<HistoricData>)
    serializer.WriteObject(stream, data)

let loadHistoricData (stream : System.IO.Stream) =
    let serializer = DataContractSerializer(typeof<HistoricData>)
    serializer.ReadObject(stream) :?> HistoricData

