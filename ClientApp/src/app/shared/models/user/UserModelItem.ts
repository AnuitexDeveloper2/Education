import { BaseModel } from 'src/app/shared/models/Base/BaseModel';

export class UserModelItem extends BaseModel {

    userName: string;
    firstName: string;
    lastName: string;
    email: string;
    id: number;
    role: string
    lockoutEnabled: boolean;
    password: string;

}