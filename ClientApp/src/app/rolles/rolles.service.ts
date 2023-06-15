import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class RollesService {

  constructor(private http: HttpClient) { }

  getRolles(){
    return this.http.get('${environment.appUrl}/api/Rolles/get-Rolles')
  }
}
