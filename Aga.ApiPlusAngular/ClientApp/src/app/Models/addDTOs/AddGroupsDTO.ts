export class AddGroupDTo{
    name : string;
    image : string;
    idTeacher: number;

    isValid(): boolean {
        if (
            this.name == "" || this.image == "" || this.idTeacher == NaN
        ) {

            return false
        }
        else {
            return true;
        }
    }
   }