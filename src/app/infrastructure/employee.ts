export class Employee {
  id: number;
  name: string;
  address: string;
  age: number;
  email: string;
  salary: number;
  bio: string;
  hob: string[];
  constructor() {
    (this.id = 0),
      (this.name = ''),
      (this.address = ''),
      (this.age = 0),
      (this.salary = 0),
      (this.email = ''),
      (this.bio = ''),
      (this.hob = []);
  }
}
