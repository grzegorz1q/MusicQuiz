import { Injectable } from '@angular/core';
import { jwtDecode } from 'jwt-decode';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  getId(): string{
    const token = localStorage.getItem("token");
    if(token){
      const payload: any = jwtDecode(token);
      return payload["sub"];
    }
    return '';
  }
}
