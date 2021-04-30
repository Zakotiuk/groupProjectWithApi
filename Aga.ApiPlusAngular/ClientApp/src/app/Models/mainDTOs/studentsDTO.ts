export class StudentDTo{
    id : string;
    name : string;
    image : string;
    age : number;
    isPay : boolean;
    idGroup : number

    isValid(): boolean {
        if (
            this.name == "" || this.image == "" || this.age == NaN || this.idGroup == NaN
        ) {

            return false
        }
        else {
            return true;
        }
    }
   }