import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ReservacionService {
  public URL: string = '';

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string
  ) {
    this.URL = `${baseUrl}reservacion`;
  }

  public async Add(item: any): Promise<any>{
    return new Promise<boolean>(resolve => {
      this.http.put<boolean>(`${this.URL}/Add`, item).subscribe(result => {
        resolve(result);
      }, (error: any) => {
        console.error(error["error"]);
      });
    });
  }

  public async GetAll(): Promise<any> {
    return new Promise<any>(resolve => {
      this.http.get<any>(`${this.URL}/GetAll`).subscribe(result => {
        resolve(result);
      }, error => console.error(error));
    });
  }
}
