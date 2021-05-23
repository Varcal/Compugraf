export class ResponseModel<T> {
    statusCode:number = 0;
    data: T | undefined;
    message: string = "";

    
}