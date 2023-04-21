import { State } from './state.interface';
export interface City {
  id: number;
  name: string;
  stateId:number;
  state:State;
}
