export class Apiresponse{
    public code : number;
    public message : string;
    public token : string;
    public errors: any;
}

export class ApiCollectionResponse extends Apiresponse{
    data!:Array<any>;
}