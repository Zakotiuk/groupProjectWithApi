export class AddCourseDTo{
    name : string;
    image : string;
    idTeacher: number;
    description : string;
    smth : string 

    isValid(): boolean {
         if (
             this.name == "" || this.image == "" || this.idTeacher == NaN || this.description == "" || this.smth == ""
         ) {
 
             return false
         }
         else {
             return true;
         }
     }

   }