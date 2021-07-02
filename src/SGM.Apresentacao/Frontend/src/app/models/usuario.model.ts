import { Papel } from './papel.model';

export class Usuario
{
    id?: number;
    nome?: string;
    email: string;
    senha?: string;
    papeis: Papel[];
    token: string;
    ehContribuinte: boolean;
    ehServidor: boolean;
    ehGestor: boolean;
}