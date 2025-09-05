# biblioteca.py
# Aplicación para registrar libros en una biblioteca
# Compatible con Visual Studio Code (Windows, Mac, Linux)

def mostrar_menu():
    print("\n=== MENÚ DE LA BIBLIOTECA ===")
    print("1. Registrar libro")
    print("2. Mostrar todos los libros")
    print("3. Buscar libro por título")
    print("4. Cambiar estado del libro (prestado/disponible)")
    print("5. Salir")


# Diccionario para almacenar los libros: ISBN como clave
biblioteca = {}

# Conjunto para validar títulos únicos
titulos = set()

def registrar_libro():
    print("\n--- Registrar nuevo libro ---")
    isbn = input("Ingrese ISBN (único): ")

    if isbn in biblioteca:
        print("⚠️ Este ISBN ya está registrado.")
        return

    titulo = input("Ingrese el título: ")
    if titulo.lower() in titulos:
        print("⚠️ Este título ya existe.")
        return

    autor = input("Ingrese el autor: ")
    genero = input("Ingrese el género: ")
    anio = input("Ingrese el año de publicación: ")

    # Almacenar datos del libro
    biblioteca[isbn] = {
        "titulo": titulo,
        "autor": autor,
        "genero": genero,
        "anio": anio,
        "estado": "disponible"
    }

    titulos.add(titulo.lower())
    print("✅ Libro registrado con éxito.")

def mostrar_libros():
    print("\n--- Lista de libros registrados ---")
    if not biblioteca:
        print("📚 No hay libros registrados aún.")
        return

    for isbn, datos in biblioteca.items():
        print(f"\nISBN: {isbn}")
        for clave, valor in datos.items():
            print(f"{clave.capitalize()}: {valor}")
        print("-" * 30)

def buscar_libro():
    print("\n--- Buscar libro por título ---")
    titulo = input("Ingrese el título a buscar: ").lower()

    encontrados = False
    for datos in biblioteca.values():
        if datos["titulo"].lower() == titulo:
            print(f"\nTítulo: {datos['titulo']}")
            print(f"Autor: {datos['autor']}")
            print(f"Género: {datos['genero']}")
            print(f"Año: {datos['anio']}")
            print(f"Estado: {datos['estado']}")
            encontrados = True

    if not encontrados:
        print("❌ Libro no encontrado.")

def cambiar_estado():
    print("\n--- Cambiar estado de libro ---")
    isbn = input("Ingrese ISBN del libro: ")

    if isbn not in biblioteca:
        print("❌ Libro no encontrado.")
        return

    estado_actual = biblioteca[isbn]["estado"]
    nuevo_estado = "prestado" if estado_actual == "disponible" else "disponible"
    biblioteca[isbn]["estado"] = nuevo_estado

    print(f"✅ Estado actualizado a: {nuevo_estado}")

def main():
    while True:
        mostrar_menu()
        opcion = input("Seleccione una opción (1-5): ")

        if opcion == "1":
            registrar_libro()
        elif opcion == "2":
            mostrar_libros()
        elif opcion == "3":
            buscar_libro()
        elif opcion == "4":
            cambiar_estado()
        elif opcion == "5":
            print("👋 Saliendo del sistema. ¡Hasta luego!")
            break
        else:
            print("❌ Opción inválida. Intente nuevamente.")

# Punto de entrada del programa
if __name__ == "__main__":
    main()

    
  



