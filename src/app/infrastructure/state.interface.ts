import { Country } from "./country.interface";

export interface State {
  id: number;
  name: string;
  countryId:number;
  country:Country;
}
