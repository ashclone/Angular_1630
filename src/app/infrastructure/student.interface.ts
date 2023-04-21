import { address } from "./address.interface";
import { gender } from "./gender.interface";

export interface student{
  id:number,
  name:string ,
  birthDate:Date,
  email:string,
  contact:string,
  profileImage:string,
  genderId:number,
  address:address,
  gender:gender
}
