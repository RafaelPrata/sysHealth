export class LocalVariables {

    public static codigoUsuario(): number {
       return Number(localStorage.getItem('codigoUsuario'));
    }
    public static codigoPerfilUsuario(): number {
        return Number(localStorage.getItem('codigoPerfilUsuario'));
    }

    public static setVariable(key: string, value: string) {
        localStorage.setItem(key, value);
    }

    public static getVariable(key: string): string {
        return localStorage.getItem(key);
    }

    public static removeVariable(key: string) {
        localStorage.removeItem(key);
    }

    public static limparDados() {
        localStorage.clear();
    }

}