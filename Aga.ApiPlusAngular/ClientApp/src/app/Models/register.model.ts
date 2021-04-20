export class RegisterModel{
    public Email : string;
    public Password : string;
    public Phone : string;
    public Fullname : string;
    public Adress : string;
    public Age : number;

    isValid() : boolean{
        if(this.Email != "" &&
         this.Password != "" &&
         this.Phone != "" &&
            this.Fullname != "" &&
            this.Adress != "" &&
            this.Age > 15 && this.Age < 100
            ){
            return true;
        }else{
            return false;
        }
    }
    isEmail(){
        const re = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return re.test(String(this.Email).toLowerCase());
    }
}