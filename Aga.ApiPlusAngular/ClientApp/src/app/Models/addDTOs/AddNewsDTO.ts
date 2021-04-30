export class AddNewDTO{
    image : string;
    title : string;

    isValid(): boolean {
        if (
            this.title == "" || this.image == ""
        ) {

            return false
        }
        else {
            return true;
        }
    }
   }