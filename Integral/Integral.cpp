#include <iostream>
#include <cmath>

using namespace std;


double f(double x, double a, double b, double n) {
    return pow(a * x + b, n);
}


double integrate(double a, double b, double n, double lower, double upper, double eps) {
    int N = 10;  
    double prev_integral = 0.0, integral = 0.0;

    do {
        double h = (upper - lower) / N; 
        integral = 0.0;

        for (int i = 0; i < N; i++) {
            double x_mid = lower + (i + 0.5) * h; 
            integral += f(x_mid, a, b, n) * h;
        }

        if (fabs(integral - prev_integral) < eps) break;
        prev_integral = integral;
        N *= 2; 
    } while (true);

    return integral;
}

int main() {
    setlocale(LC_ALL, "Russian");
    double a, b, n, lower, upper, eps;

    cout << "Введите коэффициенты a, b, n: ";
    cin >> a >> b >> n;
    cout << "Введите пределы интегрирования (нижний, верхний): ";
    cin >> lower >> upper;
    cout << "Введите точность вычисления eps: ";
    cin >> eps;

    double result = integrate(a, b, n, lower, upper, eps);

    cout << "Приближённое значение интеграла: " << result << endl;

    return 0;
}
