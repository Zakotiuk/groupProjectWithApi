export class TeacherDTo{    
    id : string;
    name : string;
    image : string;
    description : string;
    age : number;
    rates : number; 

    isValid(): boolean {
        if (
            this.name == "" || this.image == "" || this.description == "" || this.age == NaN || this.rates == NaN 
        ) {

            return false
        }
        else {
            return true;
        }
    }
   }