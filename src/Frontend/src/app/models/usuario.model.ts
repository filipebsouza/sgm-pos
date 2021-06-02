import { Papel } from './papel.model';

export class Usuario
{
    id?: number;
    email: string;
    senha: string;
    papeis: Papel[];
    token: string;
}